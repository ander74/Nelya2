#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using Nelya.ChartJs.Enums;
using System.Drawing;

namespace Nelya.ChartJs.Models;


public class Dataset {

    public ChartType ChartType { get; set; } = ChartType.None;


    public string Label { get; set; }


    public IEnumerable<decimal> Data { get; set; }


    public IEnumerable<Color> BackgroundColors { get; set; }


    public IEnumerable<Color> HoverBackgroundColors { get; set; }


    public IEnumerable<Color> BorderColors { get; set; }


    public IEnumerable<Color> HoverBorderColors { get; set; }


    public IEnumerable<int> BorderWidths { get; set; }


    public IEnumerable<int> BorderRadius { get; set; }


    public IEnumerable<int> Offset { get; set; }


    public IEnumerable<int> HoverOffset { get; set; }


    public int Spacing { get; set; }


    public Fill Fill { get; set; }


    public int StackId { get; set; }


    public decimal Tension { get; set; }


    public int Order { get; set; }







}
