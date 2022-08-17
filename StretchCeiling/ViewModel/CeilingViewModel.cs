using CommunityToolkit.Mvvm.ComponentModel;
using StretchCeiling.Model;

namespace StretchCeiling.ViewModel
{
    public partial class CeilingViewModel : ObservableObject
    {
        //public CeilingViewModel(Ceiling ceiling)
        //{
        //    Points = ceiling.Scheme.Points;
        //    Price = ceiling.Price.ToString();
        //}
        [ObservableProperty] public PointCollection _points;
        [ObservableProperty] private string name;
        [ObservableProperty] private string count;
        [ObservableProperty] private string price;
        [ObservableProperty] private string measurementSystem;
       
    }
}
