using StretchCeiling.View.Pages;

namespace StretchCeiling;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
        Routing.RegisterRoute(nameof(BuilderPage), typeof(BuilderPage));
    }
}
