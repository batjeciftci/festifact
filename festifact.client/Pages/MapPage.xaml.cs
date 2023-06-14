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

        festimap.Pins.Add(new Microsoft.Maui.Controls.Maps.Pin
        {
            Label = "Dance festival",
            Location = new Location(51.59081589011429, 4.78657290855584),
        });

        festimap.Pins.Add(new Microsoft.Maui.Controls.Maps.Pin
        {
            Label = "Dance festival",
            Location = new Location(51.59403861274361, 4.9785726081738755),
        });

        festimap.Pins.Add(new Microsoft.Maui.Controls.Maps.Pin
        {
            Label = "Film festival",
            Location = new Location(51.69459626424829, 4.701167841156638),
        });

        festimap.Pins.Add(new Microsoft.Maui.Controls.Maps.Pin
        {
            Label = "Literature festival",
            Location = new Location(52.37754319999389, 4.655590219421085),
        });
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
    }
}
