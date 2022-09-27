using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StretchCeiling.Model;
using StretchCeiling.Service;
using StretchCeiling.View.Pages;

namespace StretchCeiling.ViewModel
{
    public partial class ListOrderViewModel : BaseViewModel
    {
        private readonly OrderService _orderService;
        private CeilingService _ceilingService;

        [ObservableProperty] private List<Order> _orders;

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
            Order order = new();
            CeilingService ceilingService = new CeilingService(order);
            var query = new Dictionary<string, object>
            {
                { nameof(Order), order},
                { nameof(OrderService), _orderService},
                { nameof(CeilingService), ceilingService}
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
