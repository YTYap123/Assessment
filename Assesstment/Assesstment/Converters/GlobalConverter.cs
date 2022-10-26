using Assesstment.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Assesstment.Converters
{
    public class GlobalConverter
    {
    }

    #region Catalog Converter

    #region isPromotion Color Converter
    public class isPromotionColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isPromotion = (bool)value;

            if (isPromotion)
            {
                return Color.DarkOrange;
            }
            else
            {
                return Color.FromHex("#275faa");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    #endregion

    #endregion
}
