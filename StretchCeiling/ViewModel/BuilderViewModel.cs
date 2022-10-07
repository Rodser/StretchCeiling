
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StretchCeiling.Model;
using StretchCeiling.View.Pages;

namespace StretchCeiling.ViewModel
{
    public partial class BuilderViewModel : BaseViewModel, IQueryAttributable
    {
        private Order _order;
        private Ceiling _ceiling;

        [ObservableProperty] private PointCollection _points;
        [ObservableProperty] private List<Side> _sides;
        [ObservableProperty] private double _perimeter;
        [ObservableProperty] private double _square;
        [ObservableProperty] private List<Equipment> _equipments;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey(nameof(Ceiling)))
            {
                _ceiling = (Ceiling)query[nameof(Ceiling)];
                _order = (Order)query[nameof(Order)];

                Sides = _ceiling.Scheme.Sides;
                Points = _ceiling.Points;
                Perimeter = _ceiling.Perimeter;
                Square = _ceiling.Square;
                _equipments = _ceiling.Equipments;
            }
            if (query.ContainsKey("updated"))
            {
                bool updated = (bool)query["updated"];
                if (updated)
                {
                    Perimeter = _ceiling.GetPerimeter();
                    Square = _ceiling.GetSquare();
                    _ceiling.RefreshPrice();
                    Points = _ceiling.Points;
                }
            }
        }

        [RelayCommand]
        private async void OpenEditorSegment()
        {
            var query = new Dictionary<string, object>
            {
                {nameof(Scheme), _ceiling.Scheme }
            };
            await Shell.Current.GoToAsync(nameof(EditorSegmentPage), query);
        }

        [RelayCommand]
        private void ClearPoints(object sender)
        {
            Points.Clear();
            Sides.Clear();
            Points.Add(Point.Zero);
        }

        [RelayCommand]
        private async Task GoBackAddCeiling()
        {
            if (Sides.Count > 0)
            {
                _order.AddCeiling(_ceiling);
            }
            //var queryUpdate = new Dictionary<string, object>
            //{
            //    {"updated", true }
            //};
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task AddComponent()
        {
            var query = new Dictionary<string, object>
            {
                { nameof(Equipment), _equipments }
            };
            await Shell.Current.GoToAsync(nameof(ComponentPage), query);
        }
    }
}
