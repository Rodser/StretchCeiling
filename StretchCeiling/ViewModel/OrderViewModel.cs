using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StretchCeiling.Model;
using StretchCeiling.Service;
using StretchCeiling.View.Pages;
using System.Collections.ObjectModel;

namespace StretchCeiling.ViewModel
{
    public partial class OrderViewModel : BaseViewModel, IQueryAttributable
    {
        private OrderService _orderService;
        private CeilingService _ceilingService;
        private Order _order;

        [ObservableProperty] public double _price;
        [ObservableProperty] private List<Ceiling> _ceilings;

        [RelayCommand]
        private async Task BuildCeiling()
        {
            var query = new Dictionary<string, object>
            {
                { nameof(CeilingService), _ceilingService },
            };
            await Shell.Current.GoToAsync(nameof(BuilderPage), query);
        }

        [RelayCommand]
        private async Task GoBackAddOrder()
        {
             await _orderService.AddOrder(_order);

            var query = new Dictionary<string, object>
            {
                {"updated", true }
            };
            await Shell.Current.GoToAsync("..", query);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey(nameof(Order)))
            {
                _orderService = (OrderService)query[nameof(OrderService)];
                _order = (Order)query[nameof(Order)];
                _ceilingService = (CeilingService)query[nameof(CeilingService)];
            }

            if (query.ContainsKey("updated"))
            {
                bool updated = (bool)query["updated"];
                if (updated)
                {
                    Ceilings = _ceilingService.GetCeilings();
                    Price = _ceilingService.TotalPrice;
                    _order.Price = Price;
                }
            }
        }
    }
}
