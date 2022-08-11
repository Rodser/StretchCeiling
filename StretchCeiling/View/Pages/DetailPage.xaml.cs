using StretchCeiling.ViewModel;

namespace StretchCeiling
{
	public partial class DetailPage : ContentPage
	{
		public DetailPage(DetailViewModel vm)
		{
			InitializeComponent();
			BindingContext = vm;
		}
	}
}