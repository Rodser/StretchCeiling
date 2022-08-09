using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StretchCeiling.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            Items = new ObservableCollection<string>();
        }

        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string count;

        [ObservableProperty]
        private string price;

        [ObservableProperty]
        private string measurementSystem;

        [RelayCommand]
        private void Add()
        {
            if (string.IsNullOrWhiteSpace(name) &&
                string.IsNullOrWhiteSpace(count) &&
                string.IsNullOrWhiteSpace(price) &&
                string.IsNullOrWhiteSpace(measurementSystem))
                return;

            string newItem = CreateItem();
            items.Add(newItem);
        }


        [RelayCommand]
        private async Task Tap(string s)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?DetailText={s}");
        }

        [RelayCommand]
        private void Delete(string s)
        {
            if (Items.Contains(s))
            {
                Items.Remove(s);
            }
        }

        private string CreateItem()
        {
            return $"{name} ({price} руб) : {count} {measurementSystem}";
        }
    }
}
