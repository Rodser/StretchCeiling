﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StretchCeiling.Model;
using StretchCeiling.View.Pages;
using System.Collections.ObjectModel;

namespace StretchCeiling.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        private Ceiling _lastCeiling;

        public MainViewModel()
        {
            _ceilings = AppShell.CeilingSerxice.GetCeilings();
        }

        [ObservableProperty] private ObservableCollection<Ceiling> _ceilings;
        [ObservableProperty] private string price;

        [RelayCommand]
        private async void Add()
        {
            await Shell.Current.GoToAsync(nameof(DetailPage));
        }

        [RelayCommand]
        private async Task BuildCeiling()
        {
            _lastCeiling = new Ceiling();            
            //_ceilings.Add(_lastCeiling);

            var query = new Dictionary<string, object>
            {
                { nameof(Ceiling), _lastCeiling }
            };

            await Shell.Current.GoToAsync(nameof(BuilderPage), query);
        }

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
 