#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using System.Windows;
using System.Windows.Controls;

namespace Nelya.Wpf.Controls.FakeGrid;


public class FakeGrid : StackPanel {


    // ====================================================================================================
    #region CAMPOS PRIVADOS Y CONSTRUCTOR
    // ====================================================================================================


    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region PROPIEDADES
    // ====================================================================================================



    public GridLength DefinitionWidth {
        get => (GridLength)GetValue(DefinitionWidthProperty);
        set => SetValue(DefinitionWidthProperty, value);
    }
    public static readonly DependencyProperty DefinitionWidthProperty =
        DependencyProperty.Register("DefinitionWidth", typeof(GridLength), typeof(FakeGrid), new PropertyMetadata());


    public GridLength ValueWidth {
        get => (GridLength)GetValue(ValueWidthProperty);
        set => SetValue(ValueWidthProperty, value);
    }
    public static readonly DependencyProperty ValueWidthProperty =
        DependencyProperty.Register("ValueWidth", typeof(GridLength), typeof(FakeGrid), new PropertyMetadata());




    #endregion
    // ====================================================================================================



}