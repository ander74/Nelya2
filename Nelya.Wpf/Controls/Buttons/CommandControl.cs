#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using System.Windows;
using System.Windows.Input;

namespace Nelya.Wpf.Controls.Buttons;


/// <summary>
/// Expone un <see cref="RelayCommand"/> para ser usado desde el 'Code Behind' de un elemento que no contiene comandos.
/// </summary>
public class CommandControl : FrameworkElement {

    public ICommand Command {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }
    public static readonly DependencyProperty CommandProperty =
        DependencyProperty.Register("Command", typeof(ICommand), typeof(CommandControl), new PropertyMetadata());


}
