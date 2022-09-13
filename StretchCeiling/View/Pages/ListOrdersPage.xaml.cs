using StretchCeiling.ViewModel;

namespace StretchCeiling.View.Pages;

public partial class ListOrdersPage : ContentPage
{
	public ListOrdersPage(ListOrderViewModel listOrderViewModel)
	{
		InitializeComponent();
		BindingContext = listOrderViewModel;
	}
}