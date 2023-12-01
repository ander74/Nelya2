#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion

using Nelya.Core.Helpers;

namespace Nelya.Core.Collections;


/// <summary>
/// Representa un <see cref="List{Range}<"/> en la que se puede comprobar si contiene un índice concreto.
/// </summary>
public class RangeCollection : List<Range> {


    // ====================================================================================================
    #region CAMPOS PRIVADOS Y CONSTRUCTOR
    // ====================================================================================================


    public RangeCollection() : base() { }


    /// <summary>
    /// Instancia un objeto <see cref="RangeCollection"/> con una serie de rangos extraidos de la expresión
    /// proporcionada.<br/>
    /// La expresión contendrá rangos separados por comas, los cuales pueden ser un único número (se creará
    /// un rango con inicio y final en ese número) o valores separados por un guión (-) o por dos puntos
    /// seguidos (..) para indicar el inicio y el final del rango.<br/>
    /// Ej: La expresión "12,21..25,30-40" añadiría 3 rangos: el 12, del 21 al 25 y del 30 al 40.
    /// </summary>
    public RangeCollection(string expression) {
        AddFromExpression(expression);
    }

    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region MÉTODOS PÚBLICOS
    // ====================================================================================================

    public bool Contains(int valor) {
        return this.Any(r => valor >= r.Start.Value && valor <= r.End.Value);
    }

    /// <summary>
    /// Añade una serie de rangos parseando la expresión proporcionada.<br/>
    /// La expresión contendrá rangos separados por comas, los cuales pueden ser un único número (se creará
    /// un rango con inicio y final en ese número) o valores separados por un guión (-) o por dos puntos
    /// seguidos (..) para indicar el inicio y el final del rango.<br/>
    /// Ej: La expresión "12,21..25,30-40" añadiría 3 rangos: el 12, del 21 al 25 y del 30 al 40.<br/>
    /// Si la expresión contiene algún rango no válido, se ignorará, pero se añadirán el resto de rangos válidos.
    /// </summary>
    public void AddFromExpression(string expression) {
        expression = expression.Replace(" ", "").Replace("..", "-");
        if (string.IsNullOrEmpty(expression)) return;
        var rangos = expression.Split(',');
        foreach (var rango in rangos) {
            var r = rango.AsRange();
            if (r.Start.Value == 0 && r.End.Value == 0) continue;
            Add(r);
        }
    }


    #endregion
    // ====================================================================================================



}