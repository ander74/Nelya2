#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using Nelya.ChartJs.Enums;
using System.Text;

namespace Nelya.ChartJs.Models;


public class Chart {

    public ChartType ChartType { get; set; }


    public bool IsResponsive { get; set; } = true;


    public IEnumerable<string> Labels { get; set; }


    public IEnumerable<Dataset> Datasets { get; set; }


    public bool IsHorizontal { get; set; } = false;


    public Title Legend { get; set; }


    public Title Title { get; set; }


    public Title Subtitle { get; set; }


    public decimal SuggestedMin { get; set; }


    public decimal SuggestedMax { get; set; }


    /// <summary>
    /// Tamaño del agujero en el gráfico de pastel.
    /// </summary>
    public decimal CutOut { get; set; }


    /// <summary>
    /// Si es true, el valor de <see cref="CutOut"/> se refiere a porcentaje.
    /// </summary>
    public bool IsCutOutPercentaje { get; set; } = false;


    /// <summary>
    /// Radio del gráfico de pastel.
    /// </summary>
    public int Radius { get; set; }


    /// <summary>
    /// Si es true, el valor de <see cref="Radius"/> se refiere a porcentaje.
    /// </summary>
    public bool IsRadiusPercentage { get; set; } = false;



    // ====================================================================================================
    #region MÉTODOS PÚBLICOS
    // ====================================================================================================

    public string GenerateJsonConfig() {

        if (ChartType == ChartType.None) return string.Empty;
        var texto = new StringBuilder();
        texto.Append("{");
        texto.Append(GetChartType());
        texto.Append($"'responsive': {IsResponsive.ToString().ToLower()},");
        texto.Append(GetData());
        texto.Append(GetOptions());
        texto.Append("}");


        return texto.ToString().Replace("'", "\""); ;

    }

    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region MÉTODOS PRIVADOS
    // ====================================================================================================


    private string GetChartType() {
        if (ChartType == ChartType.None) return string.Empty;
        return $"'type': '{ChartType.ToString().ToLower()}',";
    }


    private string GetData() {
        if (Datasets == null || !Datasets.Any()) return string.Empty;
        var texto = new StringBuilder();
        texto.Append("'data': {");
        if (Labels != null && Labels.Any()) {
            texto.Append("'labels': [");
            foreach (var label in Labels) texto.Append($"'{label}',");
            texto.Append("],");
        }
        texto.Append("'datasets': [");
        if (Datasets != null && Datasets.Any()) {
            foreach (var dataset in Datasets) {
                texto.Append("{");
                if (dataset.Label != null) texto.Append($"'label': '{dataset.Label}',");
                if (dataset.Data != null && dataset.Data.Any()) {
                    texto.Append("'data': [");
                    foreach (var data in dataset.Data) texto.Append($"{data},");
                    texto.Append("],");
                }
                if (dataset.ChartType != ChartType && dataset.ChartType != ChartType.None) {
                    texto.Append($"'type': '{dataset.ChartType.ToString().ToLower()}',");
                }
                if (dataset.BackgroundColors != null && dataset.BackgroundColors.Any()) {
                    texto.Append("'backgroundColor': [");
                    foreach (var color in dataset.BackgroundColors) {
                        var alfa = Math.Round((color.A / 255m), 2);
                        texto.Append($"'rgba({color.R}, {color.G}, {color.B}, {alfa})',");
                    }
                    texto.Append("],");
                }
                if (dataset.HoverBackgroundColors != null && dataset.HoverBackgroundColors.Any()) {
                    texto.Append("'hoverBackgroundColor': [");
                    foreach (var color in dataset.HoverBackgroundColors) {
                        var alfa = Math.Round((color.A / 255m), 2);
                        texto.Append($"'rgba({color.R}, {color.G}, {color.B}, {alfa})',");
                    }
                    texto.Append("],");
                }
                if (dataset.BorderColors != null && dataset.BorderColors.Any()) {
                    texto.Append("'borderColor': [");
                    foreach (var color in dataset.BorderColors) {
                        var alfa = Math.Round((color.A / 255m), 2);
                        texto.Append($"'rgba({color.R}, {color.G}, {color.B}, {alfa})',");
                    }
                    texto.Append("],");
                }
                if (dataset.HoverBorderColors != null && dataset.HoverBorderColors.Any()) {
                    texto.Append("'hoverBorderColor': [");
                    foreach (var color in dataset.HoverBorderColors) {
                        var alfa = Math.Round((color.A / 255m), 2);
                        texto.Append($"'rgba({color.R}, {color.G}, {color.B}, {alfa})',");
                    }
                    texto.Append("],");
                }
                if (dataset.BorderWidths != null && dataset.BorderWidths.Any()) {
                    texto.Append("'borderWidth': [");
                    foreach (var width in dataset.BorderWidths) texto.Append($"{width},");
                    texto.Append("],");
                }
                if (dataset.BorderRadius != null && dataset.BorderRadius.Any()) {
                    texto.Append("'borderRadius': [");
                    foreach (var radius in dataset.BorderRadius) texto.Append($"{radius},");
                    texto.Append("],");
                }
                if (dataset.Offset != null && dataset.Offset.Any()) {
                    texto.Append("'offset': [");
                    foreach (var offset in dataset.Offset) texto.Append($"{offset},");
                    texto.Append("],");
                }
                if (dataset.HoverOffset != null && dataset.HoverOffset.Any()) {
                    texto.Append("'hoverOffset': [");
                    foreach (var offset in dataset.HoverOffset) texto.Append($"{offset},");
                    texto.Append("],");
                }
                if (dataset.Spacing != 0) texto.Append($"'spacing': {dataset.Spacing},");
                if (dataset.Fill != Fill.None) {
                    if (dataset.Fill == Fill.Origin) {
                        texto.Append($"'fill': 'origin',");
                    } else {
                        var fill = dataset.Fill switch {
                            Fill.Dataset_0 => 0,
                            Fill.Dataset_1 => 1,
                            Fill.Dataset_2 => 2,
                            Fill.Dataset_3 => 3,
                            Fill.Dataset_4 => 4,
                            Fill.Dataset_5 => 5,
                            Fill.Dataset_6 => 6,
                            Fill.Dataset_7 => 7,
                            Fill.Dataset_8 => 8,
                            Fill.Dataset_9 => 9,
                            _ => 0,
                        };
                        texto.Append($"'fill': {fill},");
                    }
                }
                if (dataset.StackId != 0) texto.Append($"'stack': {dataset.StackId},");
                if (dataset.Tension != 0m) texto.Append($"'tension': {dataset.Tension},");
                if (dataset.Order != 0) texto.Append($"'order': {dataset.Order},");
                texto.Append("},");
            }
        }
        texto.Append("]},");

        return texto.ToString();
    }


    private string GetOptions() {
        var texto = new StringBuilder();
        texto.Append("'options': {");
        texto.Append(IsHorizontal ? "'indexAxis': 'y'," : "'indexAxis': 'x',");
        if (CutOut != 0m) texto.Append(IsCutOutPercentaje ? $"'cutout': '{CutOut}%'," : $"'cutout': {CutOut},");
        if (Radius != 0m) texto.Append(IsRadiusPercentage ? $"'radius': '{Radius}%'," : $"'radius': {Radius},");
        texto.Append(GetPlugins());
        texto.Append("'scales':{");
        texto.Append("'y': {");
        texto.Append("'beginAtZero': true,");
        texto.Append($"'suggestedMin': {SuggestedMin},");
        texto.Append($"'suggestedMax': {SuggestedMax},");

        texto.Append("},"); // Y
        texto.Append("},"); // Scales
        texto.Append("},"); // Options

        return texto.ToString();
    }


    private string GetPlugins() {
        var texto = new StringBuilder();
        var vacio = true;
        texto.Append("'plugins':{");
        if (Legend != null) {
            vacio = false;
            texto.Append("'legend': {");
            texto.Append($"'display': {Legend.IsDisplayed.ToString().ToLower()},");
            texto.Append($"'text': '{Legend.Text}',");
            if (Legend.Position == Position.ChartArea) {
                texto.Append("'position': 'chartArea',");
            } else {
                texto.Append($"'position': '{Legend.Position.ToString().ToLower()}',");
            }
            texto.Append($"'align': '{Legend.Alignment.ToString().ToLower()}',");
            texto.Append("},");
        }
        if (Title != null) {
            vacio = false;
            texto.Append("'title': {");
            texto.Append($"'display': {Title.IsDisplayed.ToString().ToLower()},");
            texto.Append($"'text': '{Title.Text}',");
            if (Title.Position == Position.ChartArea) {
                texto.Append("'position': 'chartArea',");
            } else {
                texto.Append($"'position': '{Title.Position.ToString().ToLower()}',");
            }
            texto.Append($"'align': '{Title.Alignment.ToString().ToLower()}',");
            texto.Append("},");
        }
        if (Subtitle != null) {
            vacio = false;
            texto.Append("'subtitle': {");
            texto.Append($"'display': {Subtitle.IsDisplayed.ToString().ToLower()},");
            texto.Append($"'text': '{Subtitle.Text}',");
            if (Subtitle.Position == Position.ChartArea) {
                texto.Append("'position': 'chartArea',");
            } else {
                texto.Append($"'position': '{Subtitle.Position.ToString().ToLower()}',");
            }
            texto.Append($"'align': '{Subtitle.Alignment.ToString().ToLower()}',");
            texto.Append("},");
        }
        texto.Append("},");
        return vacio ? string.Empty : texto.ToString();
    }

    #endregion
    // ====================================================================================================











}
