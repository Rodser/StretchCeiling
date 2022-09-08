using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StretchCeiling.Model;
using StretchCeiling.View.Pages;
using System.Collections.ObjectModel;

namespace StretchCeiling.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            _ceilings = AppShell.CeilingSerxice.GetCeilings();
            _price = AppShell.CeilingSerxice.TotalPrice;
        }

        [ObservableProperty] private ObservableCollection<Ceiling> _ceilings;
        [ObservableProperty] private double _price;

        [RelayCommand]
        private async Task BuildCeiling()
        {
            await Shell.Current.GoToAsync(nameof(BuilderPage));
        }

        //[RelayCommand]
        //private async void Add()
        //{
        //    await Shell.Current.GoToAsync(nameof(DetailPage));
        //}

        //[RelayCommand]
        //private async Task Tap(string s)
        //{
        //    await Shell.Current.GoToAsync($"{nameof(DetailPage)}?DetailText={s}");
        //}

        //[RelayCommand]
        //private void Delete(string s)
        //{
            
        //}
    }
}
 