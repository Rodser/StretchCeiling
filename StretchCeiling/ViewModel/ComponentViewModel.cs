using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StretchCeiling.Model;

namespace StretchCeiling.ViewModel
{
    public partial class ComponentViewModel : BaseViewModel, IQueryAttributable
    {
        private Ceiling _ceiling;
        private Equipment _component;

        [ObservableProperty] private string _name;
        [ObservableProperty] private string _measure;
        [ObservableProperty] private double _price;
        [ObservableProperty] private double _count;

        public ComponentViewModel()
        {
            _component = new();
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            _ceiling = query[nameof(Ceiling)] as Ceiling;
        }

        [RelayCommand]
        private async Task AddComponent()
        {
            _component.Name = Name;
            _component.Measure = Measure;
            _component.Price = Price;
            _component.Count = Count;
            _ceiling.AddComponent(_component);
                        
            var query = new Dictionary<string, object>
            {
                {"updated", true }
            };

            await Shell.Current.GoToAsync("..", query);
        }
    }
}
