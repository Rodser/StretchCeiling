using StretchCeiling.ViewModel;

namespace StretchCeiling.View.Pages;

public partial class ComponentPage : ContentPage
{
	public ComponentPage(ComponentViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}