namespace Ocelli.OpenShopify;

public interface IOnlineStoreService
{
    public IArticleClient Article { get; }
    public IAssetClient Asset { get; }
    public IBlogClient Blog { get; }
    public ICommentClient Comment { get; }
    public IPageClient Page { get; }
    public IRedirectClient Redirect { get; }
    public IScriptTagClient ScriptTag { get; }
    public IThemeClient Theme { get; }
}
public class OnlineStoreService : ShopifyService, IOnlineStoreService
{
    private readonly string _myShopifyUrl;
    private readonly Uri _baseUri;

    public OnlineStoreService(string myShopifyUrl, string shopAccessToken) : base(myShopifyUrl, shopAccessToken)
    {
        _baseUri = base.PrepareRequest(myShopifyUrl);
        _myShopifyUrl = myShopifyUrl;
    }
    
    public IArticleClient Article => new ArticleClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IAssetClient Asset => new AssetClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IBlogClient Blog => new BlogClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public ICommentClient Comment => new CommentClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IPageClient Page => new PageClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IRedirectClient Redirect => new RedirectClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IScriptTagClient ScriptTag => new ScriptTagClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
    public IThemeClient Theme => new ThemeClient(ShopifyHttpClients[_myShopifyUrl]) { BaseUrl = _baseUri.ToString(), ReadResponseAsString = true };
}