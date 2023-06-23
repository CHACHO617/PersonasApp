using PersonasApp.Pages;

namespace PersonasApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ManagePersonaPage), typeof(ManagePersonaPage));
	}
}
