
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StretchCeiling.Model;
using StretchCeiling.View.Pages;
using System.Collections.ObjectModel;

namespace StretchCeiling.ViewModel
{
    public partial class BuilderViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty] private PointCollection _points;
        [ObservableProperty] private ObservableCollection<Segment> _segments;
        [ObservableProperty] private double _perimeter;
        
        private Ceiling _ceiling;

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
        private async Task GoBack()
        {
            if(_ceiling.Scheme.Segments.Count <= 0)
            {
                _ceiling = null;
            }
            await Shell.Current.GoToAsync("..");
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey(nameof(Ceiling)))
            {
                _ceiling = query[nameof(Ceiling)] as Ceiling;
                Segments = _ceiling.Scheme.Segments;
                Points = _ceiling.Scheme.Points;
            }
            if (query.ContainsKey("updated"))
            {
                bool updated = (bool)query["updated"];
                if (updated)
                {
                    Perimeter = _ceiling.Scheme.GetPerimeter();
                }
            }
        }
    }
}
