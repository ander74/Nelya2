#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using Nelya.Core.Helpers;
using System.Globalization;
using System.Windows.Data;

namespace Nelya.Wpf.Converters;


public class MonthNameConverter : IValueConverter {

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if (value is int mes) {
            if (mes >= 1 || mes <= 12) return Textos.Meses[mes];
        }
        return "Desconocido";
    }


    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}