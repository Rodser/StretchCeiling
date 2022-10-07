using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StretchCeiling.Domain;
using StretchCeiling.Model;
using StretchCeiling.Service;
using StretchCeiling.View.Pages;
using dom = StretchCeiling.Domain.Model;

namespace StretchCeiling.ViewModel
{
    public partial class OrderViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private CeilingService _ceilingService;
        private Order _order;

        [ObservableProperty] public double _price;
        [ObservableProperty] private List<Ceiling> _ceilings;

        public OrderViewModel(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

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
            if(_order is null)
            {
                return;
            }

            var order = _mapper.Map<dom.Order>(_order);
            await _orderRepository.AddOrder(order);

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
                    _order.Ceilings = _ceilingService.GetCeilings();
                }
            }
        }
    }
}
