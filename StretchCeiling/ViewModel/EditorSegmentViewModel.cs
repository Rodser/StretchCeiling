using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StretchCeiling.Model;
using System.Collections.ObjectModel;

namespace StretchCeiling.ViewModel
{
    public partial class EditorSegmentViewModel : ObservableObject, IQueryAttributable
    {
        public EditorSegmentViewModel()
        {
            Angles = GetListAngels();
        }

        [ObservableProperty] private Angle _onSelectAngle;
        [ObservableProperty] private bool _hasPickerActive;
        [ObservableProperty] private PointCollection _points;
        [ObservableProperty] private List<Angle> _angles;
        [ObservableProperty] private double _entrySegment;
        [ObservableProperty] private ObservableCollection<Segment> _segments;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            _segments = query[nameof(Segments)] as ObservableCollection<Segment>;
            _points = query[nameof(Points)] as PointCollection;
            SetAngle();
        }

        [RelayCommand]
        private async void AddSegment()
        {
            var angle = OnSelectAngle ?? new Angle(AngleStandart.Zero); 
            if (Segments.Count > 0)
            {
                angle.SetValueDegrees(Segments[^1].Angle);
            }
            if (EntrySegment <= 0)
            {
                return;
            }
            var point = CreatePoint(EntrySegment, angle);
            Points.Add(point);
            var segment = new Segment(Points, EntrySegment, angle);
            Segments.Add(segment);

            bool updated = true;

            var query = new Dictionary<string, object>
            {
                {"updated", updated }
            };

            await Shell.Current.GoToAsync("..", query);
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        private Point CreatePoint(double distance, Angle angle)
        {
            var newX = distance * Math.Cos(angle.Radian) + Points[^1].X;
            var newY = distance * Math.Sin(angle.Radian) + Points[^1].Y;
            return new Point(newX, newY);
        }

        private static List<Angle> GetListAngels()
        {
            var angles = new List<Angle>
            {
                new Angle(AngleStandart.InternalAngle45),
                new Angle(AngleStandart.InternalAngle90),
                new Angle(AngleStandart.InternalAngle135),
                new Angle(AngleStandart.ExternalAngle135),
                new Angle(AngleStandart.ExternalAngle90),
                new Angle(AngleStandart.ExternalAngle45),
            };
            return angles;
        }

        private void SetAngle()
        {
            if (Segments.Count > 0)
            {
                OnSelectAngle = new Angle(AngleStandart.InternalAngle90);
                HasPickerActive = true;
            }
            else
            {
                OnSelectAngle = new Angle(AngleStandart.Zero);
                HasPickerActive = false;
            }
        }
    }
}
