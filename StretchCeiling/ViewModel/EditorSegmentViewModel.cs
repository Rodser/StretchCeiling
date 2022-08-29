using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StretchCeiling.Model;
using System.Collections.ObjectModel;

namespace StretchCeiling.ViewModel
{
    public partial class EditorSegmentViewModel : ObservableObject, IQueryAttributable
    {
        private readonly StandartAngles _standartAngles;
        private readonly string _selectedFirstAngleDefault = "0";
        private readonly string _selectedAngleDefault = "90";
     
        public EditorSegmentViewModel()
        {
            _standartAngles = new StandartAngles();
            Angles = GetListAngels(_standartAngles.Angles);            
        }

        [ObservableProperty] private string _onSelectAngle;
        [ObservableProperty] private bool _hasPickerActive;
        [ObservableProperty] private PointCollection _points;
        [ObservableProperty] private List<string> _angles;
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
            var angle = new Angle(double.Parse(OnSelectAngle ?? "0"));
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

        private static List<string> GetListAngels(List<Angle> defaultAngles)
        {
            var list = new List<string>();
            foreach (var item in defaultAngles)
            {
                list.Add(item.Degrees.ToString());
            }
            return list;
        }

        private void SetAngle()
        {
            if (Segments.Count > 0)
            {
                OnSelectAngle = _selectedAngleDefault;
                HasPickerActive = true;
            }
            else
            {
                OnSelectAngle = _selectedFirstAngleDefault;
                HasPickerActive = false;
            }
        }
    }
}
