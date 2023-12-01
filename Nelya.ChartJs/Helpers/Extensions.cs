#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using System.Drawing;

namespace Nelya.ChartJs.Helpers;


public static class Extensions {


    public static Color WithAlpha(this Color color, byte alpha) {
        return Color.FromArgb(alpha, color);
    }

}
