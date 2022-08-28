using StretchCeiling.Service;
using StretchCeiling.View.Pages;

namespace StretchCeiling;

public partial class AppShell : Shell
{
    public static CeilingService CeilingSerxice { get; set; }

    public AppShell()
	{
		InitializeComponent();
        CeilingSerxice = new CeilingService();

        Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
        Routing.RegisterRoute(nameof(BuilderPage), typeof(BuilderPage));
        Routing.RegisterRoute(nameof(EditorSegmentPage), typeof(EditorSegmentPage));
    }
}
