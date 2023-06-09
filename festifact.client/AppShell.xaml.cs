using festifact.client.Pages;
using festifact.client.ViewModels;

namespace festifact.client;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(HomeDetailsPage), typeof(HomeDetailsPage));
	}
}

