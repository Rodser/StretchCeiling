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
            Ceilings = new ObservableCollection<Ceiling>();
        }

        [ObservableProperty] private ObservableCollection<Ceiling> _ceilings;
        [ObservableProperty] private string name;
        [ObservableProperty] private PointCollection _points;
        [ObservableProperty] private string count;
        [ObservableProperty] private string price;
        [ObservableProperty] private string measurementSystem;

        private Ceiling _lastCeiling;

        [RelayCommand]
        private void Add()
        {
        }

        [RelayCommand]
        private async Task Tap(string s)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?DetailText={s}");
        }

        [RelayCommand]
        private async Task BuildCeiling()
        {
            _lastCeiling = new Ceiling();
            var query = new Dictionary<string, object>
            {
                { nameof(Ceiling), _lastCeiling }
            };
            await Shell.Current.GoToAsync(nameof(BuilderPage), query);
        }

        [RelayCommand]
        private void Delete(string s)
        {
            
        }
    }
}
 