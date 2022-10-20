using StretchCeiling.View.Pages;

namespace StretchCeiling;

public partial class AppShell : Shell
{
    public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(ListComponentsPage), typeof(ListComponentsPage));
        Routing.RegisterRoute(nameof(ListOrdersPage), typeof(ListOrdersPage));
        Routing.RegisterRoute(nameof(OrderPage), typeof(OrderPage));
        Routing.RegisterRoute(nameof(ComponentPage), typeof(ComponentPage));
        Routing.RegisterRoute(nameof(BuilderPage), typeof(BuilderPage));
        Routing.RegisterRoute(nameof(EditorSegmentPage), typeof(EditorSegmentPage));
        Routing.RegisterRoute(nameof(InfoPage), typeof(InfoPage));
    }
}
