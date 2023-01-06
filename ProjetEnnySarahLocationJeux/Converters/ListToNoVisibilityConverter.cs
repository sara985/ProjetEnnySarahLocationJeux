using ProjetEnnySarahLocationJeux.POCO;
using ProjetEnnySarahLocationJeux.POCO_MODELS;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ProjetEnnySarahLocationJeux.Converters
{
    public class ListToNoVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int count = 0;
            if (value is List<Booking>)
            {
                List<Booking> list = (List<Booking>)value;
                count = list.Count;
            }
            else if (value is List<Loan>)
            {
                List<Loan> list = (List<Loan>)value;
                count = list.Count;
            }else if(value is List<VideoGame>)
            {
                List<VideoGame> list = (List<VideoGame>)value;
                count = list.Count;
            }

            if (count == 0)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
