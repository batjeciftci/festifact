using System;
using IdentityModel.Client;
using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;

namespace festifact.client.Auth0;

public class Auth0Client
{
    private readonly OidcClient _oidcClient;


    public IdentityModel.OidcClient.Browser.IBrowser Browser
    {
        get
        {
            return _oidcClient.Options.Browser;
        }
        set
        {
            _oidcClient.Options.Browser = value;
        }
    }

    // The constructor takes the options passed as an argument and creates an instance of the OIDC client configured with them.
    public Auth0Client(Auth0ClientOptions options)
	{
        _oidcClient = new OidcClient(new OidcClientOptions
        {
            Authority = $"https://{options.Domain}",
            ClientId = options.ClientId,
            Scope = options.Scope,
            RedirectUri = options.RedirectUri,
            Browser = options.Browser
        });
    }

    // start authentication process.
    public async Task<LoginResult> LoginAsync()
    {
        return await _oidcClient.LoginAsync();
    }

    // Logout endpoint URL
    public async Task<BrowserResult> LogoutAsync()
    {

        var logoutParameters = new Dictionary<string, string>
        {
            { "client_id", _oidcClient.Options.ClientId },
            { "returnTo", _oidcClient.Options.RedirectUri }
        };

        var logoutRequest = new LogoutRequest();

        var endSessionUrl = new RequestUrl($"{_oidcClient.Options.Authority}/v2/logout")
          .Create(new Parameters(logoutParameters));

        var browserOptions = new BrowserOptions(endSessionUrl, _oidcClient.Options.RedirectUri)
        {
            Timeout = TimeSpan.FromSeconds(logoutRequest.BrowserTimeout),
            DisplayMode = logoutRequest.BrowserDisplayMode
        };

        var browserResult = await _oidcClient.Options.Browser.InvokeAsync(browserOptions);

        return browserResult;
    }
}

