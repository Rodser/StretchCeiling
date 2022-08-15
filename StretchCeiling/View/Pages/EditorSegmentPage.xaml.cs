using StretchCeiling.ViewModel;

namespace StretchCeiling.View.Pages;

public partial class EditorSegmentPage : ContentPage
{
	public EditorSegmentPage(EditorSegmentViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}