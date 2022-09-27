using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StretchCeiling.Model;
using StretchCeiling.Service;
using StretchCeiling.View.Pages;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace StretchCeiling.ViewModel
{
    public partial class ListOrderViewModel : BaseViewModel
    {
        private readonly OrderService _orderService;
        [ObservableProperty] private ObservableCollection<Order> _orders;

        public ListOrderViewModel(OrderService orderService)
        {
            _orderService = orderService;
            _ = Refresh();
        }

        [RelayCommand]
        private async Task Refresh()
        {
            await GetOrdersAsync();
        }

        private async Task GetOrdersAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                Orders = await _orderService.GetOrders();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task AddOrder()
        {
            var order = new Order { Ceilings = new ObservableCollection<Ceiling>() };
            var query = new Dictionary<string, object>
            {
                { nameof(Order), order},
                { nameof(OrderService), _orderService}
            };
            await Shell.Current.GoToAsync(nameof(OrderPage), query);
        }

        [RelayCommand]
        private async Task DeleteOrderAsync(Order selected)
        {
            var x = await Shell.Current.DisplayActionSheet("o bosse", "NO", "Realy delete this order?");
            if (x== "Realy delete this order?")
            {
                await _orderService.DeleteOrder(selected);
                
            
                //Orders = await _orderService.GetOrders();
            }
        }
    }
}
