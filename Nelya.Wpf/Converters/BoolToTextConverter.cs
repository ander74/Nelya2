#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using System.Globalization;
using System.Windows.Data;

namespace Nelya.Wpf.Converters;


public class BoolToTextConverter : IValueConverter {


    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if (value is bool b) {
            return b ? "Sí" : "No";
        }
        return "No";
    }


    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        if (value is string s) {
            return s.ToUpper() switch {
                "S" => true,
                "SI" => true,
                "SÍ" => true,
                "N" => false,
                "NO" => false,
                "V" => true,
                "F" => false,
                "1" => true,
                "0" => false,
                _ => false,
            };
        }
        return false;
    }


}