#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Nelya.Core.Helpers;
using Nelya.Pdf.PdfDataSet.Enums;
using Nelya.Pdf.PdfDataSet.Models;
using System.Diagnostics;
using Win = System.Drawing;

namespace Nelya.Pdf.PdfDataSet.Helpers;


/// <summary>
/// Provee métodos para facilitar la conversión de PdfDataSet a IText y viceversa.
/// </summary>
public static class PdfHelperForIText {


    // ====================================================================================================
    #region Métodos de extensión
    // ====================================================================================================

    /// <summary>
    /// Convierte el PdfBorder al Border de IText 7.
    /// </summary>
    public static Border ToItextBorder(this PdfBorder pdfBorder) {
        switch (pdfBorder) {
            case PdfBorder.SOLID_THIN: return new SolidBorder(0.4f);
            case PdfBorder.SOLID_MEDIUM: return new SolidBorder(0.8f);
            case PdfBorder.SOLID_THICK: return new SolidBorder(1.5f);
            case PdfBorder.LINES_THIN: return new DashedBorder(0.4f);
            case PdfBorder.LINES_MEDIUM: return new DashedBorder(0.8f);
            case PdfBorder.LINES_THICK: return new DashedBorder(1.5f);
            case PdfBorder.DOTS_THIN: return new RoundDotsBorder(0.4f);
            case PdfBorder.DOTS_MEDIUM: return new RoundDotsBorder(0.8f);
            case PdfBorder.DOTS_THICK: return new RoundDotsBorder(1.5f);
            case PdfBorder.DOUBLE_THIN: return new DoubleBorder(0.8f);
            case PdfBorder.DOUBLE_MEDIUM: return new DoubleBorder(1.5f);
            case PdfBorder.DOUBLE_THICK: return new DoubleBorder(2.8f);
        }
        return Border.NO_BORDER;
    }


    /// <summary>
    /// Convierte el Color de Windows (System.Drawing) al color de IText 7.
    /// </summary>
    public static Color ToItextColor(this Win.Color color) => new DeviceRgb(color.R, color.G, color.B);

    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region Métodos privados
    // ====================================================================================================


    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region Métodos de estilos
    // ====================================================================================================


    /// <summary>
    /// Devuelve la fuente Helvetica en formato IText 7, que es la predeterminada para las tablas.
    /// </summary>
    public static PdfFont GetFont() => PdfFontFactory.CreateFont(StandardFonts.HELVETICA);


    /// <summary>
    /// Crea un estilo IText 7 para una tabla.
    /// </summary>
    public static Style GetTableStyle(PdfDataTable table) {
        Style style = new Style();
        style.SetTextAlignment(TextAlignment.CENTER)
            .SetVerticalAlignment(VerticalAlignment.MIDDLE)
            .SetMargins(0, 0, 0, 0)
            .SetPaddings(0, 0, 0, 0)
            .SetWidth(UnitValue.CreatePercentValue(100))
            .SetFont(GetFont())
            .SetFontSize(table.CellsFontSize);
        return style;
    }


    /// <summary>
    /// Crea un estilo IText 7 para el título de la tabla.
    /// </summary>
    public static Style GetTitleStyle(PdfDataTable table) {
        Style style = new Style();
        style.SetBold()
            .SetBorder(Border.NO_BORDER)
            .SetTextAlignment(TextAlignment.LEFT)
            .SetFontSize(table.TitleFontSize);
        return style;
    }


    /// <summary>
    /// Crea un estilo IText 7 para el logo de la tabla.
    /// </summary>
    public static Style GetLogoStyle() {
        Style style = new Style();
        style.SetBorder(Border.NO_BORDER)
            .SetTextAlignment(TextAlignment.RIGHT);
        return style;
    }


    /// <summary>
    /// Crea un estilo IText 7 para las celdas de encabezado.
    /// </summary>
    public static Style GetHeaderCellStyle(PdfDataTable table) {
        Style style = new Style();
        style.SetBackgroundColor(table.HeadersBackground.ToItextColor())
            .SetBold()
            .SetVerticalAlignment(VerticalAlignment.MIDDLE)
            .SetFontSize(table.HeadersFontSize)
            .SetFontColor(table.HeadersForeground.ToItextColor())
            .SetBorderTop(table.TableBorder.ToItextBorder())
            .SetBorderBottom(PdfBorder.SOLID_MEDIUM.ToItextBorder());
        return style;
    }


    /// <summary>
    /// Crea un estilo IText 7 para la primera celda de encabezado.
    /// </summary>
    public static Style GetFirstHeaderCellStyle(PdfDataTable table) {
        Style style = new Style();
        style.SetBorderLeft(table.TableBorder.ToItextBorder())
            .SetVerticalAlignment(VerticalAlignment.MIDDLE);
        return style;
    }


    /// <summary>
    /// Crea un estilo IText 7 para la última celda de encabezado.
    /// </summary>
    public static Style GetLastHeaderCellStyle(PdfDataTable table) {
        Style style = new Style();
        style.SetBorderRight(table.TableBorder.ToItextBorder())
            .SetVerticalAlignment(VerticalAlignment.MIDDLE);
        return style;
    }


    /// <summary>
    /// Crea un estilo IText 7 para una celda de datos de una tabla.
    /// </summary>
    public static Style GetCellStyle(PdfDataTable table) {
        Style style = new Style();
        style.SetBackgroundColor(table.RowsBackground.ToItextColor())
            .SetVerticalAlignment(VerticalAlignment.MIDDLE);
        return style;
    }


    /// <summary>
    /// Crea un estilo IText 7 para la primera celda de datos de la fila.
    /// </summary>
    public static Style GetFirstCellStyle(PdfDataTable table) {
        Style style = new Style();
        style.SetBorderLeft(table.TableBorder.ToItextBorder())
            .SetVerticalAlignment(VerticalAlignment.MIDDLE);
        return style;
    }


    /// <summary>
    /// Crea un estilo IText 7 para la última celda de datos de la fila.
    /// </summary>
    public static Style GetLastCellStyle(PdfDataTable table) {
        Style style = new Style();
        style.SetBorderRight(table.TableBorder.ToItextBorder())
            .SetVerticalAlignment(VerticalAlignment.MIDDLE);
        return style;
    }


    /// <summary>
    /// Crea un estilo IText 7 para las celdas de filas alternas.
    /// </summary>
    public static Style GetAlterneCellStyle(PdfDataTable table) {
        Style style = new Style();
        style.SetBackgroundColor(table.AlternateRowsBackground.ToItextColor())
            .SetVerticalAlignment(VerticalAlignment.MIDDLE);
        return style;
    }


    /// <summary>
    /// Crea un estilo IText 7 para una celda de totales.
    /// </summary>
    public static Style GetTotalsCellStyle(PdfDataTable table) {
        Style style = new Style();
        style.SetBackgroundColor(table.HeadersBackground.ToItextColor())
            .SetBold()
            .SetVerticalAlignment(VerticalAlignment.MIDDLE)
            .SetFontSize(table.HeadersFontSize)
            .SetFontColor(table.HeadersForeground.ToItextColor())
            .SetBorderTop(PdfBorder.SOLID_MEDIUM.ToItextBorder())
            .SetBorderBottom(table.TableBorder.ToItextBorder());
        return style;
    }


    /// <summary>
    /// Crea un estilo IText 7 para la primera celda de totales.
    /// </summary>
    public static Style GetFirstTotalsCellStyle(PdfDataTable table) {
        Style style = new Style();
        style.SetBorderLeft(table.TableBorder.ToItextBorder())
            .SetVerticalAlignment(VerticalAlignment.MIDDLE);
        return style;
    }


    /// <summary>
    /// Crea un estilo IText 7 para la última celda de totales.
    /// </summary>
    public static Style GetLastTotalsCellStyle(PdfDataTable table) {
        Style style = new Style();
        style.SetBorderRight(table.TableBorder.ToItextBorder())
            .SetVerticalAlignment(VerticalAlignment.MIDDLE);
        return style;
    }


    /// <summary>
    /// Crea un estilo IText 7 basado en las propiedades de una celda individual.
    /// </summary>
    public static Style GetIndividualCellStyle(PdfDataCell celda) {
        var style = new Style();
        if (celda.Foreground is Win.Color foreground) style.SetFontColor(foreground.ToItextColor());
        if (celda.Background is Win.Color background) style.SetFontColor(background.ToItextColor());
        if (celda.FontSize is int fontSize) style.SetFontSize(fontSize);
        if (celda.IsBold) style.SetBold();
        if (celda.IsItalic) style.SetItalic();
        switch (celda.TextAlign) {
            case PdfTextAlign.LEFT:
                style.SetTextAlignment(TextAlignment.LEFT);
                break;
            case PdfTextAlign.RIGHT:
                style.SetTextAlignment(TextAlignment.RIGHT);
                break;
            case PdfTextAlign.CENTER:
                style.SetTextAlignment(TextAlignment.CENTER);
                break;
            case PdfTextAlign.JUSTIFY:
                style.SetTextAlignment(TextAlignment.JUSTIFIED);
                break;
        }
        switch (celda.VerticalAlign) {
            case PdfVerticalAlign.TOP:
                style.SetVerticalAlignment(VerticalAlignment.TOP);
                break;
            case PdfVerticalAlign.MIDDLE:
                style.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                break;
            case PdfVerticalAlign.BOTTOM:
                style.SetVerticalAlignment(VerticalAlignment.BOTTOM);
                break;
        }
        if (celda.Borders.left != PdfBorder.DEFAULT) style.SetBorderLeft(celda.Borders.left.ToItextBorder());
        if (celda.Borders.right != PdfBorder.DEFAULT) style.SetBorderRight(celda.Borders.right.ToItextBorder());
        if (celda.Borders.top != PdfBorder.DEFAULT) style.SetBorderTop(celda.Borders.top.ToItextBorder());
        if (celda.Borders.bottom != PdfBorder.DEFAULT) style.SetBorderBottom(celda.Borders.bottom.ToItextBorder());
        return style;
    }

    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region Métodos de tablas
    // ====================================================================================================


    /// <summary>
    /// Crea una tabla con un título a la izquierda y un logo a la derecha para incluirla como título de una tabla más grande.
    /// </summary>
    public static Table GetTitleTable(PdfDataTable table) {
        Table tabla = new Table(UnitValue.CreatePercentArray(new float[] { 70, 30 }));
        tabla.AddStyle(GetTableStyle(table));
        Paragraph parrafo = new Paragraph(table.Title).SetFixedLeading(16);
        tabla.AddCell(new Cell().Add(parrafo).AddStyle(GetTitleStyle(table)));
        Image imagen = GetImageFromFile(table.LogoPath);
        if (imagen != null) {
            imagen.SetHeight(35);
            imagen.SetHorizontalAlignment(HorizontalAlignment.RIGHT);
            tabla.AddCell(new Cell().Add(imagen).AddStyle(GetLogoStyle()));
        }
        return tabla;
    }


    /// <summary>
    /// Crea una tabla con los encabezados, datos y totales del objeto <see cref="PdfDataTable"/> proporcionado, aplicando los estilos que éste contiene.
    /// </summary>
    public static Table GetTable(PdfDataTable table) {
        // Generamos la tabla con el título y el logo.
        var tablaTitulo = GetTitleTable(table);
        // Creamos la tabla a devolver usando los anchos de columna.
        var tabla = new Table(UnitValue.CreatePercentArray(table.ColumnWidths.ToArray()));
        tabla.SetHorizontalAlignment(HorizontalAlignment.CENTER);
        tabla.AddStyle(GetTableStyle(table));
        // Insertamos lá tabla de título
        tabla.AddHeaderCell(new Cell(1, table.ColumnWidths.Count()).Add(tablaTitulo).AddStyle(GetTitleStyle(table))); //TODO: Verificar si el estilo Title está repetido, ya que aparece en el método GetTitleTable.
        // Insertamos los encabezados, si existen.
        int columna = 0;
        if (table.HeaderRow?.Cells?.Any() ?? false) {
            foreach (var header in table.HeaderRow.Cells) {
                if (!header.IsMerged) {
                    columna += header.MergedColumns;
                    var celda = new Cell(header.MergedRows, header.MergedColumns);
                    celda.Add(new Paragraph(header.Value?.ToString() ?? string.Empty))
                        .AddStyle(GetHeaderCellStyle(table))
                        .AddStyle(GetIndividualCellStyle(header));
                    if (columna == 1) celda.AddStyle(GetFirstHeaderCellStyle(table));
                    if (columna == table.HeaderRow.Cells.Count) celda.AddStyle(GetLastHeaderCellStyle(table));
                    tabla.AddHeaderCell(celda);
                }
            }
        }
        // Inertamos las celdas, si existen.
        var isFondoAlterno = false;
        int filaAlterna = 1;
        int fila = 1;
        if (table.Rows?.Any() ?? false) {
            foreach (var row in table.Rows) {
                columna = 0;
                foreach (var cell in row.Cells) {
                    if (!cell.IsMerged) {
                        columna += cell.MergedColumns;
                        var celda = new Cell(cell.MergedRows, cell.MergedColumns);
                        celda.Add(new Paragraph(cell.Value?.ToString() ?? string.Empty))
                            .AddStyle(GetCellStyle(table))
                            .AddStyle(GetIndividualCellStyle(cell));
                        if (columna == 1) celda.AddStyle(GetFirstCellStyle(table));
                        if (columna == row.Cells.Count) celda.AddStyle(GetLastCellStyle(table));
                        if (isFondoAlterno) celda.AddStyle(GetAlterneCellStyle(table));
                        tabla.AddCell(celda);
                    }
                }
                if (filaAlterna == table.AlternateRowsCount) {
                    isFondoAlterno = !isFondoAlterno;
                    filaAlterna = 0;
                }
                filaAlterna++;
                fila++;
            }
        }
        // Insertamos los totales, si existen
        if (table.TotalRow?.Cells?.Any() ?? false) {
            columna = 0;
            foreach (var total in table.TotalRow.Cells) {
                if (!total.IsMerged) {
                    columna += total.MergedColumns;
                    var celda = new Cell(total.MergedRows, total.MergedColumns);
                    celda.Add(new Paragraph(total.Value?.ToString() ?? string.Empty))
                        .AddStyle(GetTotalsCellStyle(table))
                        .AddStyle(GetIndividualCellStyle(total));
                    if (columna == 1) celda.AddStyle(GetFirstTotalsCellStyle(table));
                    if (columna == table.TotalRow.Cells.Count) celda.AddStyle(GetLastTotalsCellStyle(table));
                    tabla.AddCell(celda);
                }
            }
        }

        // Ponemos el borde inferior de la tabla.
        tabla.SetBorderBottom(table.TableBorder.ToItextBorder());

        // Devolvemos la tabla
        return tabla;
    }


    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region Métodos de archivos
    // ====================================================================================================


    /// <summary>
    /// Crea un documento PDF de iText 7 en la ruta proporcionada listo para añadir elementos en él.
    /// </summary>
    public static Document GetNewDocument(string ruta, bool apaisado = false, float margins = 25f) {
        // Se crea el Writer con la ruta pasada.
        PdfWriter writer = new PdfWriter(ruta);
        // Se crea el PDF que se guardará usando el writer.
        PdfDocument docPDF = new PdfDocument(writer);
        // Creamos el tamaño de página y le asignamos la rotaciñon si debe ser apaisado.
        PageSize tamañoPagina;
        if (apaisado) {
            tamañoPagina = PageSize.A4.Rotate();
        } else {
            tamañoPagina = PageSize.A4;
        }
        // Se crea el documento con el que se trabajará.
        Document documento = new Document(docPDF, tamañoPagina);
        documento.SetMargins(margins, margins, margins, margins);
        return documento;
    }


    /// <summary>
    /// Carga la imagen que se encuentra en la ruta proporcionada en un objeto imagen de IText 7.
    /// </summary>
    public static Image GetImageFromFile(string path) {
        Image imagen = null;
        if (File.Exists(path)) {
            switch (System.IO.Path.GetExtension(path).ToLower()) {
                case ".jpg":
                    imagen = new Image(ImageDataFactory.CreateJpeg(new Uri(path)));
                    break;
                case ".png":
                    imagen = new Image(ImageDataFactory.CreatePng(new Uri(path)));
                    break;
            }
        }
        return imagen;
    }


    /// <summary>
    /// Abre el documento PDF proporcionado en la ruta a través de un proceso de sistema.
    /// </summary>
    public static void OpenPdfFile(string ruta) {
        var processInfo = new ProcessStartInfo {
            FileName = ruta,
            UseShellExecute = true,
        };
        Process.Start(processInfo);
    }

    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region Métodos de PdfDataRows
    // ====================================================================================================

    public static void Prueba() {
        var lista = new List<DateTime> {
            new DateTime(2022,10,1),
            new DateTime(2022,9,1),
            new DateTime(2022,8,1),
            new DateTime(2022,7,1),
            new DateTime(2022,6,1),
            new DateTime(2022,5,1),
            new DateTime(2022,4,1),
        };

        var rows = lista.Select(d => new PdfDataRow(new List<string> {
                d.Day.ToString(),
                d.Month.ToString(),
                d.Year.ToString(),
            })
        );


    }

    public static IEnumerable<PdfDataRow> ToPdfDataRow(this IEnumerable<object> lista, IEnumerable<object> datos) {
        var resultado = lista.Select(o => new PdfDataRow(
            datos.Select(d => d switch {
                int i => i.ToString("00"),
                decimal de => de.ToString("0.00"),
                TimeSpan t => t.ToTexto(),
                DateTime dt => dt.ToString("dd-MM-yyyy"),
                _ => d is null ? string.Empty : d.ToString(),
            }))
        );
        return resultado;
    }




    #endregion
    // ====================================================================================================


}

