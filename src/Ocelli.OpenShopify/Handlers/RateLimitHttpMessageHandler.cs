using System.Collections.Concurrent;
using System.Web;

// ReSharper disable once CheckNamespace
namespace Ocelli.OpenShopify;

internal class RateLimitHttpMessageHandler : DelegatingHandler
{
    private static readonly ConcurrentDictionary<string, AsyncRateLimitedSemaphore> CallsPerMinuteSemaphore = new();
    
    public int CallsPerMinute = 40;

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        //var now = DateTimeOffset.Now.ToUnixTimeSeconds();
        if (request.RequestUri == null) return await base.SendAsync(request, cancellationToken);

        var integrator = request.RequestUri.Host;
        var facility = HttpUtility.ParseQueryString(request.RequestUri.Query).Get("licenseNumber") ?? integrator;
        if (facility == "NA")
            throw new ArgumentException($@"The provided license is invalid: {request.RequestUri.AbsoluteUri}");
        
        CallsPerMinuteSemaphore.TryAdd(integrator,
            new AsyncRateLimitedSemaphore(CallsPerMinute, TimeSpan.FromMinutes(1)));
        
        await CallsPerMinuteSemaphore[integrator].WaitAsync();
        var result = await base.SendAsync(request, cancellationToken);

        return result;
    }

    private class AsyncRateLimitedSemaphore
    {
        private readonly int _maxCount;

        private readonly object _resetTimeLock = new();
        private readonly TimeSpan _resetTimeSpan;

        private readonly SemaphoreSlim _semaphore;
        private long _nextResetTimeTicks;

        public AsyncRateLimitedSemaphore(int maxCount, TimeSpan resetTimeSpan)
        {
            _maxCount = maxCount;
            _resetTimeSpan = resetTimeSpan;

            _semaphore = new SemaphoreSlim(maxCount, maxCount);
            _nextResetTimeTicks = (DateTimeOffset.UtcNow + _resetTimeSpan).UtcTicks;
        }

        private void TryResetSemaphore()
        {
            // quick exit if before the reset time, no need to lock
            if (!(DateTimeOffset.UtcNow.UtcTicks > Interlocked.Read(ref _nextResetTimeTicks))) return;

            // take a lock so only one reset can happen per period
            lock (_resetTimeLock)
            {
                var currentTime = DateTimeOffset.UtcNow;
                // need to check again in case a reset has already happened in this period
                if (currentTime.UtcTicks > Interlocked.Read(ref _nextResetTimeTicks))
                {
                    _semaphore.Release(_maxCount - _semaphore.CurrentCount);

                    var newResetTimeTicks = (currentTime + _resetTimeSpan).UtcTicks;
                    Interlocked.Exchange(ref _nextResetTimeTicks, newResetTimeTicks);
                }
            }
        }

        public async Task WaitAsync()
        {
            // attempt a reset in case it's been some time since the last wait
            TryResetSemaphore();

            var semaphoreTask = _semaphore.WaitAsync();

            // if there are no slots, need to keep trying to reset until one opens up
            while (!semaphoreTask.IsCompleted)
            {
                var ticks = Interlocked.Read(ref _nextResetTimeTicks);
                var nextResetTime = new DateTimeOffset(new DateTime(ticks, DateTimeKind.Utc));
                var delayTime = nextResetTime - DateTimeOffset.UtcNow;

                // delay until the next reset period
                // can't delay a negative time so if it's already passed just continue with a completed task
                var delayTask = delayTime >= TimeSpan.Zero ? Task.Delay(delayTime) : Task.CompletedTask;

                await Task.WhenAny(semaphoreTask, delayTask);

                TryResetSemaphore();
            }
        }
    }
}