using StretchCeiling.ViewModel;

namespace StretchCeiling.View.Pages
{
	public partial class BuilderPage : ContentPage
	{
		public BuilderPage(BuilderViewModel vm)
		{
			InitializeComponent();
			BindingContext = vm;
		}
	}
}