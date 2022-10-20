using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StretchCeiling.Domain;
using StretchCeiling.Model;
using StretchCeiling.View.Pages;
using dom = StretchCeiling.Domain.Model;

namespace StretchCeiling.ViewModel
{
    public partial class OrderViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private Order _order;

        [ObservableProperty] public double _price;
        [ObservableProperty] private List<Ceiling> _ceilings;

        public OrderViewModel(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey(nameof(Order)))
            {
                _order = (Order)query[nameof(Order)];
                Ceilings = _order.Ceilings;
                Price = _order.Price;
            }
        }

        [RelayCommand]
        private async Task BuildCeiling(Ceiling ceiling)
        {
            ceiling ??= new() { Name = "Room" };
            var query = new Dictionary<string, object>
            {
                { nameof(Ceiling), ceiling },
                { nameof(Order), _order}
            };
            await Shell.Current.GoToAsync(nameof(BuilderPage), query);
        }

        [RelayCommand]
        private async Task GoBackAddOrder()
        {
            var order = _mapper.Map<dom.Order>(_order);
            await _orderRepository.AddOrder(order);

            var query = new Dictionary<string, object>
            {
                {"updated", true }
            };
            await Shell.Current.GoToAsync("..", query);
        }
    }
}
