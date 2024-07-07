using System.Globalization;
using System.Windows.Data;

namespace QuestBasedDialogueSystemTool.Converters
{
    class AspectRatioConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double multiplier = 1.0;

            if (parameter != null && double.TryParse(parameter.ToString(), out double result))
            {
                multiplier = result;
            }

            return (double)value * multiplier;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double multiplier = 1.0;

            if (parameter != null && double.TryParse(parameter.ToString(), out double result))
            {
                multiplier = result;
            }

            return (double)value / multiplier;
        }
    }
}
