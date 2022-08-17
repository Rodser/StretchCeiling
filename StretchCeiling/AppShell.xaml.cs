using StretchCeiling.Model;
using StretchCeiling.View.Pages;
using System.Collections.ObjectModel;

namespace StretchCeiling;

public partial class AppShell : Shell
{
    public static ObservableCollection<Ceiling> s_ceilings;

    public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
        Routing.RegisterRoute(nameof(BuilderPage), typeof(BuilderPage));
        Routing.RegisterRoute(nameof(EditorSegmentPage), typeof(EditorSegmentPage));


        s_ceilings = new ObservableCollection<Ceiling>();
    }
}
