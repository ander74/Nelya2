#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using Nelya.Core.Helpers;
using Nelya.Pdf.PdfDataSet.Enums;
using System.Drawing;

namespace Nelya.Pdf.PdfDataSet.Models;


public class PdfDataCell {


    // ====================================================================================================
    #region Campos privados y constructor
    // ====================================================================================================


    /// <summary>
    /// Instancia una celda vacía.
    /// </summary>
    public PdfDataCell() : this(string.Empty) { }


    /// <summary>
    /// Instancia una celda con el valor establecido.
    /// </summary>
    public PdfDataCell(string value) {
        Value = value;
    }


    /// <summary>
    /// Instancia una celda con el <see cref="int"/> en modo texto y formato '00' o el definido por el argumento format.
    /// </summary>
    public PdfDataCell(int value, string format = "00") {
        Value = value.ToString(format);
    }


    /// <summary>
    /// Instancia una celda con el <see cref="decimal"/> en modo texto y formato '0.00' o el definido por el argumento format.
    /// </summary>
    public PdfDataCell(decimal value, string format = "0.00") {
        Value = value.ToString(format);
    }


    /// <summary>
    /// Instancia una celda con el <see cref="TimeSpan"/> en modo texto con formato 'hh:mm' y los valores proporcionados en los argumentos.
    /// </summary>
    public PdfDataCell(TimeSpan value, bool max24h = false, bool noZero = false) {
        Value = value.ToTexto(max24h, noZero);
    }


    /// <summary>
    /// Instancia una celda con el <see cref="DateTime"/> en modo texto con el formato 'dd-MM-yyyy' o el definido por el argumento format.
    /// </summary>
    public PdfDataCell(DateTime value, string format = "dd-MM-yyyy") {
        Value = value.ToString(format);
    }


    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region Propiedades
    // ====================================================================================================


    /// <summary>
    /// Valor de la celda.
    /// </summary>
    public string Value { get; set; }


    /// <summary>
    /// Establece el número de filas y columnas que ocupa la celda.
    /// </summary>
    //public (int rows, int cols) MergedCells { get; set; }


    /// <summary>
    /// Establece el número de filas que ocupa la celda.
    /// </summary>
    public int MergedRows { get; set; } = 1;


    /// <summary>
    /// Establece el número de columnas que ocupa la celda.
    /// </summary>
    public int MergedColumns { get; set; } = 1;


    /// <summary>
    /// Si es true, indica que la celda ha de saltarse ya que su espacio lo ocupa una celda anterior que tiene MergedCells mayor que 1.
    /// </summary>
    public bool IsMerged { get; set; }


    /// <summary>
    /// Tamaño de texto de la celda. Si es nulo, se coge el de la tabla.
    /// </summary>
    public int? FontSize { get; set; } = null;


    /// <summary>
    /// Color de texto de la celda. Si es nulo, se coge el de la tabla.
    /// </summary>
    public Color? Foreground { get; set; } = null;


    /// <summary>
    /// Color de fondo de la celda. Si es nulo, se coge el de la tabla.
    /// </summary>
    public Color? Background { get; set; } = null;


    /// <summary>
    /// Si es true, el texto se pone en negrita.
    /// </summary>
    public bool IsBold { get; set; }


    /// <summary>
    /// Si es true, el texto se pone en cursiva.
    /// </summary>
    public bool IsItalic { get; set; }


    /// <summary>
    /// Alineación horizontal de la celda.
    /// </summary>
    public PdfTextAlign TextAlign { get; set; } = PdfTextAlign.CENTER;


    /// <summary>
    /// Alineación vertical de la celda.
    /// </summary>
    public PdfVerticalAlign VerticalAlign { get; set; } = PdfVerticalAlign.MIDDLE;


    /// <summary>
    /// Bordes de la celda. Si es -1, no se modifica el estilo por defecto.
    /// </summary>
    public (PdfBorder left, PdfBorder top, PdfBorder right, PdfBorder bottom) Borders { get; set; } = (PdfBorder.DEFAULT, PdfBorder.DEFAULT, PdfBorder.DEFAULT, PdfBorder.DEFAULT);


    #endregion
    // ====================================================================================================




}
