using StretchCeiling.ViewModel;

namespace StretchCeiling.View.Pages
{
	public partial class OrderPage : ContentPage
	{
		public OrderPage(OrderViewModel orderViewModel)
		{
			InitializeComponent();
			BindingContext = orderViewModel;
		}
	}
}