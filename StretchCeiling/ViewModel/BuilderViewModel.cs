
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StretchCeiling.Domain;
using StretchCeiling.Domain.Model;
using StretchCeiling.Model;
using StretchCeiling.Service;
using StretchCeiling.Service.Arithmetic;
using StretchCeiling.View.Pages;
using System.Collections.ObjectModel;

namespace StretchCeiling.ViewModel
{
    public partial class BuilderViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly Ceiling _ceiling;
        private CeilingService _ceilingService;

        [ObservableProperty] private List<IVertex> _points;
        [ObservableProperty] private List<ISide> _segments;
        [ObservableProperty] private double _perimeter;
        [ObservableProperty] private double _square;
        [ObservableProperty] private List<IEquipment> _equipments;

        public BuilderViewModel()
        {
            _ceiling = new();
            Segments = _ceiling.Scheme.Sides;
            Points = _ceiling.Scheme.Points;
            Perimeter = _ceiling.Perimeter;
            Square = _ceiling.Square;
            _equipments = _ceiling.Equipments;
        }

        [RelayCommand]
        private async void OpenEditorSegment()
        {
            var query = new Dictionary<string, object>
            {  
                { nameof(Segments), Segments },
                { nameof(Points), Points }
            };
            await Shell.Current.GoToAsync(nameof(EditorSegmentPage), query);
        }

        [RelayCommand]
        private void ClearPoints(object sender)
        {
            Points.Clear();
            Segments.Clear();
            Points.Add(new Vertex(0,0));
        }

        [RelayCommand]
        private async Task GoBackAddCeiling()
        {
            if (Segments.Count > 0)
            {
                _ceilingService.AddCeiling(_ceiling);
            }
            var queryUpdate = new Dictionary<string, object>
            {
                {"updated", true }
            };
            await Shell.Current.GoToAsync("..", queryUpdate);
        }

        [RelayCommand]
        private async Task AddComponent()
        {
            var query = new Dictionary<string, object>
            {
                { nameof(Ceiling), _ceiling }
            };
            await Shell.Current.GoToAsync(nameof(ComponentPage), query);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey(nameof(CeilingService)))
            {
                _ceilingService = (CeilingService)query[nameof(CeilingService)];    
            }
            if (query.ContainsKey("updated"))
            {
                bool updated = (bool)query["updated"];
                if (updated)
                {
                    Perimeter = _ceiling.GetPerimeter();
                    Square = _ceiling.GetSquare();
                    _ceiling.RefreshPrice();
                }
            }
        }
    }
}
