using festifact.client.ViewModels;
using festifact.client.Auth0;

namespace festifact.client.Pages;

public partial class ProfilePage : ContentPage
{
    private readonly Auth0Client _auth0Client;


    public ProfilePage(Auth0Client client)
	{
		InitializeComponent();

        this._auth0Client = client;        
    }


    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var loginResult = await _auth0Client.LoginAsync();

        if (!loginResult.IsError)
        {
            UsernameLbl.Text = loginResult.User.Identity.Name;

            // I did not use an image here!
            // (UserPictureImg.source = UserPictureImg is the name of an image element...)
            // UserPictureImg.Source = loginResult.User.Claims.FirstOrDefault(c => c.Type == "picture")?.Value; 

            LoginView.IsVisible = false;
            HomeView.IsVisible = true;
        }
        else
        {
            await DisplayAlert("Error", loginResult.ErrorDescription, "OK");
        }
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        var logoutResult = await _auth0Client.LogoutAsync();

        if (!logoutResult.IsError)
        {
            HomeView.IsVisible = false;
            LoginView.IsVisible = true;
        }
        else
        {
            await DisplayAlert("Error", logoutResult.ErrorDescription, "OK");
        }
    }
}

