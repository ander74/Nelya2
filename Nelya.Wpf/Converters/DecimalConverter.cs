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

/// <summary>
/// Convierte un número decimal en una cadena de texto y viceversa.<br/>
/// Se puede pasar un parámetro que sera un string con los decimales que se mostrarán.<br/>
/// Si los decimales son negativos, se mostrarán los decimales que se ponen, pero no se mostrarán
/// los valores de cero.
/// </summary>
public class DecimalConverter : IValueConverter {

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        int decimales = 2;
        bool noCeros = false;
        if (parameter is string p && int.TryParse(p, out int n)) {
            if (n < 0) {
                n = n * -1;
                noCeros = true;
            }
            decimales = n;
        }
        if (value is decimal numero) {
            if (noCeros && numero == 0m) return string.Empty;
            return numero.ToTexto(decimales);
        }
        return 0m.ToTexto(decimales);
    }


    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        if (value is string texto) {
            return texto.ToDecimal();
        }
        return 0m;
    }

}