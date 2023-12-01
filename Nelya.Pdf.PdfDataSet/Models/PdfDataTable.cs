#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using Nelya.Pdf.PdfDataSet.Enums;
using System.Drawing;

namespace Nelya.Pdf.PdfDataSet.Models;


public class PdfDataTable {


    // ====================================================================================================
    #region Campos privados y constructores
    // ====================================================================================================


    /// <summary>
    /// Instancia una tabla con todos los valores vacíos.
    /// </summary>
    public PdfDataTable() : this(string.Empty) { }


    /// <summary>
    /// Instancia una tabla con el título proporcionado.
    /// </summary>
    public PdfDataTable(string title) : this(title, 0) { }


    /// <summary>
    /// Instancia una tabla con el título proporcionado y un número determinado de columnas de igual anchura.
    /// </summary>
    public PdfDataTable(string title, int numberOfColumns) {
        Title = title;
        if (numberOfColumns > 0) {
            SetUniformWidths(numberOfColumns);
            HeaderRow = new PdfDataRow(numberOfColumns);
            TotalRow = new PdfDataRow(numberOfColumns);
        }
    }

    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region Propiedades
    // ====================================================================================================

    /// <summary>
    /// Título de la tabla.
    /// </summary>
    public string Title { get; set; } = string.Empty;


    /// <summary>
    /// Dirección del archivo que contiene el logotipo que se insertará arriba a la derecha en todas las páginas.
    /// </summary>
    public string LogoPath { get; set; }


    /// <summary>
    /// Anchos de columnas en porcentajes. La suma de todos ellos debe dar 100.
    /// </summary>
    public List<float> ColumnWidths { get; set; }


    /// <summary>
    /// Fila con los encabezados de la tabla.
    /// </summary>
    public PdfDataRow HeaderRow { get; set; }


    /// <summary>
    /// Filas de datos de la tabla.
    /// </summary>
    public List<PdfDataRow> Rows { get; set; }


    /// <summary>
    /// Fila con los totales de la tabla.
    /// </summary>
    public PdfDataRow TotalRow { get; set; }


    /// <summary>
    /// Tamaño de texto del título. Por defecto 14.
    /// </summary>
    public int TitleFontSize { get; set; } = 14;


    /// <summary>
    /// Tamaño de texto de los encabezados de columna. Por defecto 8.
    /// </summary>
    public int HeadersFontSize { get; set; } = 8;


    /// <summary>
    /// Tamaño de texto de los valores. Por defecto 7.
    /// </summary>
    public int CellsFontSize { get; set; } = 7;


    /// <summary>
    /// Tamaño de texto de los totales. Por defecto 8.
    /// </summary>
    public int TotalsFontSize { get; set; } = 8;


    /// <summary>
    /// Color de fondo de los encabezados de columna.
    /// </summary>
    public Color HeadersBackground { get; set; } = Color.FromArgb(153, 153, 153);


    /// <summary>
    /// Color de fondo de las filas de datos.
    /// </summary>
    public Color RowsBackground { get; set; } = Color.White;


    /// <summary>
    /// Color de fondo que se aplicará a las filas alternas de datos.
    /// </summary>
    public Color AlternateRowsBackground { get; set; } = Color.Gainsboro;


    /// <summary>
    /// Color de fondo de la fila de totales
    /// </summary>
    public Color TotalsBackground { get; set; } = Color.FromArgb(153, 153, 153);


    /// <summary>
    /// Color de texto del título.
    /// </summary>
    public Color TitleForeground { get; set; } = Color.Black;


    /// <summary>
    /// Color de texto de los encabezados de columna.
    /// </summary>
    public Color HeadersForeground { get; set; } = Color.Black;


    /// <summary>
    /// Color de texto de las celdas de datos.
    /// </summary>
    public Color CellsForeground { get; set; } = Color.DimGray;


    /// <summary>
    /// Color de texto de la fila de totales.
    /// </summary>
    public Color TotalsForeground { get; set; } = Color.Black;


    /// <summary>
    /// Bordes de la tabla.
    /// </summary>
    public PdfBorder TableBorder { get; set; } = PdfBorder.SOLID_MEDIUM;


    /// <summary>
    /// Indica cada cuantas filas se cambia el color de fondo al color alterno.
    /// Por defecto es 1, que significa que una fila va de un color y otra del otro.
    /// </summary>
    public int AlternateRowsCount { get; set; } = 1;


    /// <summary>
    /// Establece el tema de la tabla. Una forma rápida de aplicar los colores.
    /// </summary>
    public PdfTheme TableTheme {
        get => tableTheme;
        set {
            if (tableTheme != value) {
                tableTheme = value;
                ApplyTheme(tableTheme);
            }
        }
    }
    private PdfTheme tableTheme = PdfTheme.DEFAULT;


    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region Métodos públicos
    // ====================================================================================================


    /// <summary>
    /// Establece el número de columnas de la tabla, todas con la misma anchura.
    /// </summary>
    public void SetUniformWidths(int numberOfColumns) {
        float columnWidth = 100f / numberOfColumns;
        ColumnWidths = Enumerable.Repeat(columnWidth, numberOfColumns).ToList();
    }


    /// <summary>
    /// Añade una fila de datos con el número de columnas ya establecido.
    /// </summary>
    public PdfDataRow AddNewRow() {
        var numberOfColumns = ColumnWidths.Count;
        if (Rows == null) Rows = new();
        PdfDataRow fila = new PdfDataRow(numberOfColumns);
        Rows.Add(fila);
        return fila;
    }


    /// <summary>
    /// Añade una fila de datos con los valores proporcionados.
    /// </summary>
    public PdfDataRow AddNewRow(IEnumerable<string> valores) {
        if (valores == null) return null;
        if (Rows == null) Rows = new();
        PdfDataRow fila = new PdfDataRow(valores);
        Rows.Add(fila);
        return fila;
    }

    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region Métodos privados
    // ====================================================================================================


    /// <summary>
    /// Aplica el tema a la tabla.
    /// </summary>
    private void ApplyTheme(PdfTheme theme) {
        switch (theme) {
            case PdfTheme.YELLOW:
                HeadersBackground = Color.FromArgb(230, 195, 0);
                TotalsBackground = Color.FromArgb(230, 195, 0);
                AlternateRowsBackground = Color.FromArgb(255, 244, 179);
                RowsBackground = Color.White;
                break;
            case PdfTheme.LIGHT_BLUE:
                HeadersBackground = Color.LightSkyBlue;
                TotalsBackground = Color.LightSkyBlue;
                AlternateRowsBackground = Color.LightCyan;
                RowsBackground = Color.White;
                break;
            case PdfTheme.DARK_BLUE:
                HeadersBackground = Color.DodgerBlue;
                TotalsBackground = Color.DodgerBlue;
                AlternateRowsBackground = Color.FromArgb(206, 235, 253);
                RowsBackground = Color.White;
                break;
            case PdfTheme.DEFAULT:
            case PdfTheme.GRAY:
                HeadersBackground = Color.FromArgb(153, 153, 153);
                TotalsBackground = Color.FromArgb(153, 153, 153);
                AlternateRowsBackground = Color.Gainsboro;
                RowsBackground = Color.White;
                break;
            case PdfTheme.LIME:
                HeadersBackground = Color.YellowGreen;
                TotalsBackground = Color.YellowGreen;
                AlternateRowsBackground = Color.FromArgb(235, 245, 214);
                RowsBackground = Color.White;
                break;
            case PdfTheme.ORANGE:
                HeadersBackground = Color.FromArgb(242, 147, 64);
                TotalsBackground = Color.FromArgb(242, 147, 64);
                AlternateRowsBackground = Color.FromArgb(255, 221, 179);
                RowsBackground = Color.White;
                break;
            case PdfTheme.LIGHT_BROWN:
                HeadersBackground = Color.FromArgb(223, 112, 32);
                TotalsBackground = Color.FromArgb(223, 112, 32);
                AlternateRowsBackground = Color.FromArgb(246, 212, 188);
                RowsBackground = Color.White;
                break;
            case PdfTheme.PURPLE:
                HeadersBackground = Color.Orchid;
                TotalsBackground = Color.Orchid;
                AlternateRowsBackground = Color.FromArgb(244, 215, 244);
                RowsBackground = Color.White;
                break;
            case PdfTheme.GREEN:
                HeadersBackground = Color.MediumSeaGreen;
                TotalsBackground = Color.MediumSeaGreen;
                AlternateRowsBackground = Color.FromArgb(217, 242, 228);
                RowsBackground = Color.White;
                break;
        }
    }


    #endregion
    // ====================================================================================================







}
