using StretchCeiling.Model;
using System.Globalization;

namespace StretchCeiling.Converter
{
    internal class AngleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var angle = (AngleStandart)value;
            var angleInt = System.Convert.ToInt32(angle);
            string result = angleInt.ToString();

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var angle = (string)value;
            var angleInt = System.Convert.ToInt32(angle);
            AngleStandart result = (AngleStandart)angleInt;

            return result;
        }
    }
}
