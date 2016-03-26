// NO LICENSE
// ==========
// There is no copyright, you can use and abuse this source without limit.
// There is no warranty, you are responsible for the consequences of your use of this source.
// There is no burden, you do not need to acknowledge this source in your use of this source.

namespace guidgen
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    internal class GuidConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var guidViewModel = value as GuidViewModel;
            var guid = guidViewModel != null ? guidViewModel.Guid : Guid.Empty;
            var isUppercase = guidViewModel != null ? guidViewModel.IsUppercase : false;
            var converterParameter = parameter as string;
            var result = guid.ToString(converterParameter ?? string.Empty);
            return isUppercase ? result.ToUpperInvariant() : result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}