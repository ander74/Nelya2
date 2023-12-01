#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion

namespace Nelya.Pdf.PdfDataSet.Models;


public class PdfDataRow {


    // ====================================================================================================
    #region Campos privados y constructor
    // ====================================================================================================

    /// <summary>
    /// Instancia una fila vacía.
    /// </summary>
    public PdfDataRow() { }


    /// <summary>
    /// Instancia una fila con el número de celdas determinado.
    /// </summary>
    public PdfDataRow(int numberOfColumns) {
        Cells = Enumerable.Repeat(new PdfDataCell(), numberOfColumns).ToList();
    }


    /// <summary>
    /// Instancia una fila con una celda por cada valor proporcionado.
    /// </summary>
    public PdfDataRow(IEnumerable<string> valores) {
        if (valores != null) {
            Cells = valores.Select(s => new PdfDataCell(s)).ToList();
        }
    }


    /// <summary>
    /// Instancia una fila usando los valores de un enumerable de objetos.
    /// </summary>
    public PdfDataRow(IEnumerable<object> valores) {
        Cells = valores.Select(o => o switch {
            int i => new PdfDataCell(i),
            decimal d => new PdfDataCell(d),
            TimeSpan t => new PdfDataCell(t),
            DateTime dt => new PdfDataCell(dt),
            _ => o is null ? new PdfDataCell() : new PdfDataCell(o.ToString()),
        }).ToList();
    }

    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region Propiedades
    // ====================================================================================================


    /// <summary>
    /// Celdas de la fila.
    /// </summary>
    public List<PdfDataCell> Cells { get; set; }



    #endregion
    // ====================================================================================================


}
