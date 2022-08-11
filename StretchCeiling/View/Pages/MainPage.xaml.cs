using StretchCeiling.ViewModel;

namespace StretchCeiling
{
	public partial class MainPage : ContentPage
	{
		public MainPage(MainViewModel mvm)
		{
			InitializeComponent();
			BindingContext = mvm;
		}
	}
}

