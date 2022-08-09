using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace StretchCeiling.ViewModel
{
    [QueryProperty("TextD", "DetailText")]
    public partial class DetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private string textD;

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
