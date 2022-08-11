
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StretchCeiling.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace StretchCeiling.ViewModel
{
    public partial class BuilderViewModel : ObservableObject
    {
        public BuilderViewModel()
        {
            _repository = new Repository();
            _selectedAngleDefault = "0";
            OnSelectAngle = _selectedAngleDefault;
            Points = new PointCollection
            {
                Point.Zero,
            };
            Angles = GetListAngels(_repository.DefaultAngles);
            Segments = new ObservableCollection<Segment>();
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

        [RelayCommand]
        private void AddSegmentPoint(object sender)
        {
            var angle = new Angle(double.Parse(OnSelectAngle ?? "0"));
            if (Segments.Count > 0)
            {
                angle.SetValueDegrees(Segments[Segments.Count - 1].Angle);
                Debug.Print(Segments[Segments.Count - 1].Angle.Degrees.ToString());
            }
            var point = CreatePoint(EntrySegment, angle);
            Points.Add(point);
            var segment = new Segment(Points, EntrySegment, angle);
            Segments.Add(segment);
            HasPickerActive = true;
        }
        [RelayCommand]
        private void ClearPoints(object sender)
        {
            Points.Clear();
            Segments.Clear();
            OnSelectAngle = _selectedAngleDefault;
            Points.Add(Point.Zero);
            HasPickerActive = false;
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
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

        private Point CreatePoint(double distance, Angle angle)
        {
            var newX = distance * Math.Cos(angle.Radian) + Points[Points.Count - 1].X;
            var newY = distance * Math.Sin(angle.Radian) + Points[Points.Count - 1].Y;
            return new Point(newX, newY);
        }
    }
}
