using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FitnessApp.Converters
{
    public class BmiToColourConverter : IValueConverter
    {
        public BmiToColourConverter()
        {
            
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var convertedValue = (double)value;

            if (convertedValue == 0)
            {
                return Color.WhiteSmoke;
            }
            else if (convertedValue < 21.0)
            {
                return Color.Red;
            }
            else if (convertedValue >= 21.0 && convertedValue <= 24.9)
            {
                return Color.Green;
            }
            else if (convertedValue >= 25.0)
            {
                return Color.Red;
            }

            return Color.WhiteSmoke;
        }

        

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Empty;
        }

        
    }
}