#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion

using System.Windows;

namespace Nelya.Wpf.Controls.Text;


/// <summary>
/// Expone un <see cref="string"/> para ser usado desde el 'Code Behind' de un elemento que no contiene strings.
/// </summary>
public class StringControl : FrameworkElement {

    public string Texto {
        get => (string)GetValue(TextoProperty);
        set => SetValue(TextoProperty, value);
    }
    public static readonly DependencyProperty TextoProperty =
        DependencyProperty.Register("Texto", typeof(string), typeof(StringControl), new PropertyMetadata());


}
