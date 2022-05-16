namespace Ocelli.OpenShopify;

public record AuthorizationResult(string AccessToken, string[] GrantedScopes);
