using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StretchCeiling.Domain;
using StretchCeiling.Domain.Model;
using StretchCeiling.Model;
using StretchCeiling.Service.Arithmetic;
using System.Collections.ObjectModel;

namespace StretchCeiling.ViewModel
{
    public partial class EditorSegmentViewModel : BaseViewModel, IQueryAttributable
    {
        public EditorSegmentViewModel()
        {
            Angles = GetListAngels();
        }

        [ObservableProperty] private IAngle _onSelectAngle;
        [ObservableProperty] private int selectAngleIndex;
        [ObservableProperty] private string _degreesStr;
        [ObservableProperty] private bool _hasPickerActive;
        [ObservableProperty] private List<IVertex> _points;
        [ObservableProperty] private List<IAngle> _angles;
        [ObservableProperty] private double _entrySegment;
        [ObservableProperty] private List<ISide> _segments;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            _segments = query[nameof(Segments)] as List<ISide>;
            _points = query[nameof(Points)] as List<IVertex>;
            SetAngle();
        }

        [RelayCommand]
        private async void AddSegment()
        {
            Angle angle = (Angle)OnSelectAngle ?? new Angle(AngleStandart.Zero); 
            if (Segments.Count > 0)
            {
                angle.SetValueDegrees((Angle)Segments[^1].Angle);
            }
            if (EntrySegment <= 0)
            {
                return;
            }
            Vertex point = CreatePoint(EntrySegment, angle);
            Points.Add(point);
            var segment = new Side(Points, EntrySegment, angle);
            Segments.Add(segment);

            bool updated = true;

            var query = new Dictionary<string, object>
            {
                {"updated", updated }
            };

            await Shell.Current.GoToAsync("..", query);
        }

        private Vertex CreatePoint(double distance, Angle angle)
        {
            var newX = distance * Math.Cos(angle.Radian) + Points[^1].X;
            var newY = distance * Math.Sin(angle.Radian) + Points[^1].Y;
            return new Vertex(newX, newY);
        }

        private static List<IAngle> GetListAngels()
        {
            var angles = new List<IAngle>
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
                SelectAngleIndex = 1;
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
