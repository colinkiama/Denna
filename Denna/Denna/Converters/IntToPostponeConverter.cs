﻿using System;
using Windows.UI.Xaml.Data;

namespace Denna.Converters
{
    class IntToPostponeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var x = "";
            var val = (int)value;
            if (val == 0)
            {
                x = "Nothing postponed.";
            }
            else if (val == 1)
            {
                x = val + " task postponed.";
            }
            else
            {
                x = val + " tasks postponed.";
            }

            return x;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}