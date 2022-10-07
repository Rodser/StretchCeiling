using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StretchCeiling.Model;
using StretchCeiling.Service.Arithmetic;

namespace StretchCeiling.ViewModel
{
    public partial class EditorSegmentViewModel : BaseViewModel, IQueryAttributable
    {
        public EditorSegmentViewModel()
        {
            Angles = GetListAngels();
        }

        [ObservableProperty] private Angle _onSelectAngle;
        [ObservableProperty] private int selectAngleIndex;
        [ObservableProperty] private string _degreesStr;
        [ObservableProperty] private bool _hasPickerActive;
        [ObservableProperty] private Scheme _scheme;
        [ObservableProperty] private List<Angle> _angles;
        [ObservableProperty] private double _entrySegment;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            _scheme = query[nameof(Scheme)] as Scheme;
            SetAngle();
        }

        [RelayCommand]
        private async void AddSegment()
        {
            Angle angle = OnSelectAngle ?? new Angle(AngleStandart.Zero); 
            
            if (_scheme.Sides.Count > 0)
            {
                angle.SetValueDegrees(_scheme.Sides[^1].Angle);
            }
            if (EntrySegment <= 0)
            {
                return;
            }

            Vertex point = CreatePoint(EntrySegment, angle);
            _scheme.Points.Add(point);
            var segment = new Side(_scheme.Points, EntrySegment, angle);
            _scheme.Sides.Add(segment);

            bool updated = true;

            var query = new Dictionary<string, object>
            {
                {"updated", updated }
            };

            await Shell.Current.GoToAsync("..", query);
        }

        private Vertex CreatePoint(double distance, Angle angle)
        {
            var newX = distance * Math.Cos(angle.Radian) + _scheme.Points[^1].X;
            var newY = distance * Math.Sin(angle.Radian) + _scheme.Points[^1].Y;
            return new Vertex(newX, newY);
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
            if (_scheme.Sides.Count > 0)
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
