#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using Nelya.Core.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Nelya.Core.Helpers;


public static class Extensions {


    // ====================================================================================================
    #region TimeSpan
    // ====================================================================================================

    public static string ToTexto(this TimeSpan hora, bool max24h = false, bool noZero = false) {
        if (hora == TimeSpan.MaxValue) return "";
        if (noZero && hora.Ticks == 0) return "";
        var negativo = false;
        var horas = max24h ? hora.Hours : hora.Days * 24 + hora.Hours;
        if (horas < 0) horas = horas * -1;
        if (hora.Hours < 0 || hora.Minutes < 0) negativo = true;
        var minutos = hora.Minutes < 0 ? hora.Minutes * -1 : hora.Minutes;
        return negativo ? $"-{horas:00}:{minutos:00}" : $"{horas:00}:{minutos:00}";
    }


    public static decimal ToDecimal(this TimeSpan hora, int decimales = 6) => Math.Round(Convert.ToDecimal(hora.TotalHours), decimales);


    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region Decimal
    // ====================================================================================================

    public static string ToTexto(this decimal numero, int decimales = 2, bool noZero = false) {
        if (noZero && numero == 0m) return "";
        var texto = numero.ToString($"0.{new string('0', decimales)}", CultureInfo.InvariantCulture).Replace(".", ",");
        return texto;
    }


    public static TimeSpan ToHora(this decimal numero) {
        int horas = Convert.ToInt32(Math.Truncate(numero));
        int minutos = Convert.ToInt32(Math.Truncate((numero * 60) % 60));
        return new TimeSpan(horas, minutos, 0);
    }


    public static decimal To2Decimals(this decimal numero) => Math.Round(numero, 2);


    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region String
    // ====================================================================================================


    public static TimeSpan ToHora(this string texto) {
        if (string.IsNullOrWhiteSpace(texto)) return TimeSpan.MaxValue;
        var textos = texto.Replace(".", ":").Replace(",", ":").Split(':');
        if (textos.Length != 2) return TimeSpan.MaxValue;
        if (int.TryParse(textos[0], out int hora) && int.TryParse(textos[1], out int minutos)) {
            if (hora < 0) minutos = minutos * -1;
            return new TimeSpan(hora, minutos, 0);
        }
        return TimeSpan.MaxValue;
    }


    public static TimeSpan ToHoraNoNull(this string texto) {
        if (string.IsNullOrWhiteSpace(texto)) return TimeSpan.Zero;
        var textos = texto.Replace(".", ":").Replace(",", ":").Split(':');
        if (textos.Length != 2) return TimeSpan.Zero;
        if (int.TryParse(textos[0], out int hora) && int.TryParse(textos[1], out int minutos)) {
            if (hora < 0) minutos = minutos * -1;
            return new TimeSpan(hora, minutos, 0);
        }
        return TimeSpan.Zero;
    }


    public static decimal ToDecimal(this string texto) {
        if (string.IsNullOrWhiteSpace(texto)) return 0m;
        texto = texto.Replace(",", ".").Replace("€", "");
        if (decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal numero)) {
            return numero;
        }
        return 0m;
    }


    public static int ToInt(this string texto) {
        if (int.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out int numero)) {
            return numero;
        }
        return 0;
    }



    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region Range and index
    // ====================================================================================================


    /// <summary>
    /// Convierte el texto del objeto <see cref="string"/> en un <see cref="Range"/> parseandolo de la siguiente manera:<br/>
    /// Si es un único número, creará un rango de inicio y final igual al número en cuestión.<br/>
    /// Si son dos números separados por el caracter '-', creará un rango con inicio y final usando los dos números.<br/>
    /// Si la expresión no es válida, crea un rango con inicio y final en cero.
    /// </summary>
    public static Range AsRange(this string expression) {
        var patronNumeroUnico = new Regex(@"^\d+$");
        var patronRango = new Regex(@"^\d+-{1}\d+$");
        // Si es un único numero, se crea un Range con Start y End iguales
        if (patronNumeroUnico.IsMatch(expression)) {
            int valor = int.Parse(expression);
            return new Range(valor, valor);
        }
        // Si es un rango de números, se crea normalmente.
        if (patronRango.IsMatch(expression)) {
            var valores = expression.Split('-');
            int min = int.Parse(valores[0]);
            int max = int.Parse(valores[1]);
            return new Range(min, max);
        }
        return default;
    }


    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region Collections
    // ====================================================================================================

    public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> lista) {
        return lista is null ? new ObservableCollection<T>() : new ObservableCollection<T>(lista);
    }


    public static NotifyCollection<T> ToNotifyCollection<T>(this IEnumerable<T> lista) where T : INotifyPropertyChanged {
        return lista == null ? new NotifyCollection<T>() : new NotifyCollection<T>(lista);
    }


    #endregion
    // ====================================================================================================



}