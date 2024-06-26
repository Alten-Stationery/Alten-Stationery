﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Wpf_Stationery.Helper
{
    public class IsLessThanConverter : IValueConverter
    {
        public static readonly IValueConverter Instance = new IsLessThanConverter();

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double doubleValue = System.Convert.ToDouble(value);
            double compareToValue = System.Convert.ToDouble(parameter);

            return doubleValue < compareToValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

        public class IsGreaterThanConverter: IValueConverter
        {
        public static readonly IValueConverter Instance = new IsLessThanConverter();

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double doubleValue = System.Convert.ToDouble(value);
            double compareToValue = System.Convert.ToDouble(parameter);

            return doubleValue > compareToValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    
}