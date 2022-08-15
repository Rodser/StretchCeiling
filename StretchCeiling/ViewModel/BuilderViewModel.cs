
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StretchCeiling.Model;
using StretchCeiling.View.Pages;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace StretchCeiling.ViewModel
{
    public partial class BuilderViewModel : ObservableObject
    {
        public BuilderViewModel()
        {
            Points = new PointCollection
            {
                Point.Zero,
            };
            Segments = new ObservableCollection<Segment>();
        }

        [ObservableProperty]
        public PointCollection _points;
        [ObservableProperty]
        public double _entrySegment;
        [ObservableProperty]
        public ObservableCollection<Segment> _segments;

        [RelayCommand]
        private async void OpenEditorSegment()
        {
            var query = new Dictionary<string, object> { { nameof(Segments), Segments }, { nameof(Points), Points } };
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
            await Shell.Current.GoToAsync("..");
        }
    }
}
