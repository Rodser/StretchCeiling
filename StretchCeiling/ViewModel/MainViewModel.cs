using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StretchCeiling.Model;
using StretchCeiling.View.Pages;
using System.Collections.ObjectModel;

namespace StretchCeiling.ViewModel
{
    public partial class MainViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty] private ObservableCollection<Ceiling> _ceilings;
        [ObservableProperty] public double price;

        public MainViewModel()
        {
            _ceilings = AppShell.CeilingSerxice.GetCeilings();
        }

        [RelayCommand]
        private async Task BuildCeiling()
        {
            await Shell.Current.GoToAsync(nameof(BuilderPage));
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("updated"))
            {
                bool updated = (bool)query["updated"];
                if (updated)
                {
                    Price = AppShell.CeilingSerxice.TotalPrice; ;
                }
            }
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
 