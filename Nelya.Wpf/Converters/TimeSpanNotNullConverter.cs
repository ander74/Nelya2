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
/// Convierte un TimeSpan en una cadena de texto y viceversa.<br/>
/// Se puede pasar un parámetro con la palabra 'NoCeros' para que los valores de cero no se muestren.
/// Si el valor de entrada no es válido, devuelve TimeSpan.Zero y no TimeSpan.MaxValue.
/// </summary>
public class TimeSpanNotNullConverter : IValueConverter {

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if (value is TimeSpan hora) {
            if (parameter is string s) {
                switch (s) {
                    case "NoCeros":
                        if (hora.Ticks == 0) return string.Empty;
                        break;
                    case "Max24h":
                        return hora.ToTexto(true);
                }
            }
            return hora.ToTexto();
        }
        return string.Empty;
    }


    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        if (value is string texto) {
            if (!texto.Contains(".") && !texto.Contains(",")) {
                if (int.TryParse(texto, out int horas)) {
                    return new TimeSpan(horas, 0, 0);
                }
            }
            return texto.ToHoraNoNull();
        }
        return TimeSpan.Zero;
    }

}