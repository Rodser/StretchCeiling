using StretchCeiling.ViewModel;

namespace StretchCeiling;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel mvm)
	{
		InitializeComponent();
		BindingContext = mvm;
	}

	private void Calculate_Clicked(object sender, EventArgs e)
	{
		OutLabel.Text = $"{99.9} руб";
    }

}

