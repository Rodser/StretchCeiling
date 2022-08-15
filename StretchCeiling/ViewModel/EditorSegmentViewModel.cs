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
            _repository = new Repository();
            _selectedAngleDefault = "0";
            OnSelectAngle = _selectedAngleDefault;
            Angles = GetListAngels(_repository.DefaultAngles);
            HasPickerActive = false;
        }

        private readonly Repository _repository;
        private readonly string _selectedAngleDefault;
        [ObservableProperty]
        private string _onSelectAngle;
        [ObservableProperty]
        private bool _hasPickerActive;
        [ObservableProperty]
        public PointCollection _points;
        [ObservableProperty]
        public List<string> _angles;
        [ObservableProperty]
        public double _entrySegment;
        [ObservableProperty]
        public ObservableCollection<Segment> _segments;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Segments = query[nameof(Segments)] as ObservableCollection<Segment>;
            Points = query[nameof(Points)] as PointCollection;
        }

        [RelayCommand]
        private async void AddSegment(object sender)
        {
            var angle = new Angle(double.Parse(OnSelectAngle ?? "0"));
            if (Segments.Count > 0)
            {
                angle.SetValueDegrees(Segments[Segments.Count - 1].Angle);
            }
            var point = CreatePoint(EntrySegment, angle);
            Points.Add(point);
            var segment = new Segment(Points, EntrySegment, angle);

            var dic = new Dictionary<string, object> { { "segment", segment } };

            await Shell.Current.GoToAsync("..", dic);
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        private Point CreatePoint(double distance, Angle angle)
        {
            var newX = distance * Math.Cos(angle.Radian) + Points[Points.Count - 1].X;
            var newY = distance * Math.Sin(angle.Radian) + Points[Points.Count - 1].Y;
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
    }
}
