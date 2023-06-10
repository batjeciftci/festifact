using System;

namespace festifact.client.Auth0;


// This class collects the configuration settings for Auth0.
public class Auth0ClientOptions
{

    public string Domain { get; set; }

    public string ClientId { get; set; }

    public string RedirectUri { get; set; }

    public string Scope { get; set; }

    public IdentityModel.OidcClient.Browser.IBrowser Browser { get; set; }


    public Auth0ClientOptions()
    {
        Scope = "openid";
        RedirectUri = "myapp://callback";
        Browser = new WebBrowserAuthenticator();
    }


}

