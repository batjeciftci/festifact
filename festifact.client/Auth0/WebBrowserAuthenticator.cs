using System;
using IdentityModel.Client;
using IdentityModel.OidcClient.Browser;

namespace festifact.client.Auth0;

// this class is responsible for opening the system browser, which will show the user the Auth0 Universal Login page.
public class WebBrowserAuthenticator : IdentityModel.OidcClient.Browser.IBrowser
{


    public WebBrowserAuthenticator()
    {

    }

    public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = default)
    {
        try
        {
            WebAuthenticatorResult result = await WebAuthenticator.Default.AuthenticateAsync(
                new Uri(options.StartUrl),
                new Uri(options.EndUrl));

            var url = new RequestUrl(options.EndUrl).Create(new Parameters(result.Properties));

            return new BrowserResult
            {
                Response = url,
                ResultType = BrowserResultType.Success
            };
        }
        catch (TaskCanceledException)
        {
            return new BrowserResult
            {
                ResultType = BrowserResultType.UserCancel,
                ErrorDescription = "Login canceled by the user."
            };
        }
    }


}

