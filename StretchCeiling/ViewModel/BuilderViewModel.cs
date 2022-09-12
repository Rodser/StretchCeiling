
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StretchCeiling.Model;
using StretchCeiling.Service;
using StretchCeiling.View.Pages;
using System.Collections.ObjectModel;

namespace StretchCeiling.ViewModel
{
    public partial class BuilderViewModel : ObservableObject, IQueryAttributable
    {
        private readonly Ceiling _ceiling;
        private CeilingService _ceilingService;

        [ObservableProperty] private PointCollection _points;
        [ObservableProperty] private ObservableCollection<Segment> _segments;
        [ObservableProperty] private double _perimeter;
        [ObservableProperty] private double _square;
        [ObservableProperty] private ObservableCollection<Component> _components;

        public BuilderViewModel()
        {
            _ceiling = new();
            Segments = _ceiling.Scheme.Segments;
            Points = _ceiling.Scheme.Points;
            Perimeter = _ceiling.Perimeter;
            Square = _ceiling.Square;
            _components = _ceiling.Components;
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
            Points.Add(Point.Zero);
        }

        [RelayCommand]
        private async Task GoBackAddCeiling()
        {
            if (Segments.Count > 0)
            {
                _ceilingService.AddCeiling(_ceiling);
            }
            var query = new Dictionary<string, object>
            {
                {"updated", true }
            };
            await Shell.Current.GoToAsync("..", query);
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

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
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
