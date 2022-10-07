using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StretchCeiling.Domain;
using StretchCeiling.Model;
using StretchCeiling.Service;
using StretchCeiling.View.Pages;

namespace StretchCeiling.ViewModel
{
    public partial class ListOrderViewModel : BaseViewModel
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        [ObservableProperty] private List<Order> _orders;
        [ObservableProperty] private Order _selectedOrder;

        public ListOrderViewModel(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
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
                var context = await _orderRepository.GetOrders();
                var collection = _mapper.Map<OrdersList>(context);
                Orders = collection.Orders;
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
        private async Task OpenOrder(Order order)
        {
            order ??= new()
            {
                Address = "Street",
                CallNumber = 9997755
            };

            CeilingService ceilingService = new(order);
            var query = new Dictionary<string, object>
            {
                { nameof(Order), order},
                { nameof(CeilingService), ceilingService}
            };
            await Shell.Current.GoToAsync(nameof(OrderPage), query);
        }

        [RelayCommand]
        private async Task DeleteOrderAsync(Order selected)
        {
            var x = await Shell.Current.DisplayActionSheet("o bosse", "NO", "Realy delete this order?");
            if (x == "Realy delete this order?")
            {
                await _orderRepository.DeleteOrder(selected.Id);
            }
        }
    }
}
