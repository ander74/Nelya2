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


public class DateTimeConverter : IValueConverter {


    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if (value is DateTime fecha) {
            if (fecha.Date != DateTime.MaxValue.Date) {
                if (parameter is string formato) return fecha.ToString(formato);
                return fecha.ToString("dd-MM-yyyy");
            }
        }
        return "";
    }


    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        if (value is string texto) {
            if (string.IsNullOrWhiteSpace(texto)) return DateTime.MaxValue.Date;
            if (DateTime.TryParse(texto, out DateTime fecha)) {
                return fecha.Date;
            } else {
                return DateTime.MaxValue.Date;
            }
        }
        return DateTime.MaxValue.Date;
    }


}