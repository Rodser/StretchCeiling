using CommunityToolkit.Mvvm.ComponentModel;
using StretchCeiling.Model;

namespace StretchCeiling.ViewModel
{
    public partial class CeilingViewModel : ObservableObject
    {
        [ObservableProperty] public PointCollection _points;
        [ObservableProperty] private string name;
        [ObservableProperty] private double perimeter;
        [ObservableProperty] private string price;
        [ObservableProperty] private double square;

    }
}
