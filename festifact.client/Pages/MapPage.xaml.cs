namespace festifact.client.Pages;

public partial class MapPage : ContentPage
{
	public MapPage()
	{
		InitializeComponent();

        festimap.Pins.Add(new Microsoft.Maui.Controls.Maps.Pin
        {
            Label = "music festival",
            Location = new Location(50.8514, 5.6910),
        });
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
    }
}
