using CommunityToolkit.Mvvm.ComponentModel;
using StretchCeiling.Model;
using System.Collections.ObjectModel;

namespace StretchCeiling;

public partial class App : Application
{
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
