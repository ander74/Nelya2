#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using System.Text.RegularExpressions;

namespace Nelya.Core.Helpers;


public static class Textos {


    // ====================================================================================================
    #region CAMPOS PRIVADOS
    // ====================================================================================================

    public static string[] Meses = { "Desconocido", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };


    public static string[] MesesAbr = { "Des", "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic" };


    public static string[] DiasSemana = { "Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };


    public static string[] DiasSemanaAbr = { "Dom", "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb", "Dom" };

    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region METODOS PÚBLICOS
    // ====================================================================================================

    /// <summary>
    /// Devuelve el nombre completo o abreviado del día de la semana proporcionado.
    /// </summary>
    public static string GetDiaSemana(DayOfWeek dia, bool isAbreviated = false) => dia switch {
        DayOfWeek.Sunday => isAbreviated ? "Dom" : "Domingo",
        DayOfWeek.Monday => isAbreviated ? "Lun" : "Lunes",
        DayOfWeek.Tuesday => isAbreviated ? "Mar" : "Martes",
        DayOfWeek.Wednesday => isAbreviated ? "Mié" : "Miércoles",
        DayOfWeek.Thursday => isAbreviated ? "Jue" : "Jueves",
        DayOfWeek.Friday => isAbreviated ? "Vie" : "Viernes",
        DayOfWeek.Saturday => isAbreviated ? "Sáb" : "Sábado",
        _ => isAbreviated ? "Des" : "Desconocido",
    };


    /// <summary>
    /// Devuelve una cadena de texto eliminando los espacios extra que haya en el texto proporcionado.
    /// </summary>
    public static string QuitarEspaciosExtra(string texto) {
        RegexOptions options = RegexOptions.None;
        Regex regex = new Regex("[ ]{2,}", options);
        return regex.Replace(texto, " ");
    }


    /// <summary>
    /// Devuelve una cadena de texto eliminando los espacios iniciales y finales de cada línea del texto proporcionado.
    /// </summary>
    public static string TrimEveryLine(string texto) => string.Join('\n', texto.Split('\n').Select(t => t.Trim()));


    /// <summary>
    /// Extrae la primera aparición de un número entero dentro de una cadena de texto. Si no encuentra ninguno, devuelve -1.
    /// </summary>
    public static int ExtractInt(string texto) {
        Regex regex = new Regex(@"\d+");
        Match match = regex.Match(texto);
        if (match.Success && int.TryParse(match.Value, out int numero)) return numero;
        return -1;
    }


    /// <summary>
    /// Extrae la primera aparición de una hora en formato HH:MM (o H:MM) de una cadena de texto. Si no lo encuentra devuelve TimeSpan.MaxValue.
    /// </summary>
    public static TimeSpan ExtractTimeSpan(string texto) {
        Regex regex = new Regex(@"([0-1]?[0-9]|2[0-3]):[0-5][0-9]");
        Match match = regex.Match(texto);
        if (match.Success && TimeSpan.TryParse(match.Value, out TimeSpan hora)) return hora;
        return TimeSpan.MaxValue;
    }


    #endregion
    // ====================================================================================================


}



