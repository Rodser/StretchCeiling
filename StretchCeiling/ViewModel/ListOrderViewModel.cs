using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StretchCeiling.Model;
using StretchCeiling.View.Pages;
using System.Collections.ObjectModel;

namespace StretchCeiling.ViewModel
{
    public partial class ListOrderViewModel : ObservableObject
    {
        [ObservableProperty] private ObservableCollection<Order> orders;

        public ListOrderViewModel()
        {
            orders = AppShell.OrderService.GetOrders();
        }

        [RelayCommand]
        private async Task AddOrder()
        {
            var order = new Order { Ceilings = new ObservableCollection<Ceiling>() };
            var query = new Dictionary<string, object>
            {
                { nameof(Order), order},
            };
            await Shell.Current.GoToAsync(nameof(OrderPage), query);
        }
    }
}
