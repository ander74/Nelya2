#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using Nelya.ChartJs.Enums;

namespace Nelya.ChartJs.Models;


public class Title {

    public bool IsDisplayed { get; set; } = false;


    public string Text { get; set; } = string.Empty;


    public Position Position { get; set; } = Position.Top;


    public Align Alignment { get; set; } = Align.Center;



}
