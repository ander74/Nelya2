#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion

namespace Nelya.Maui.Controls.Label;


public partial class LabelEntry : ContentView {


    // ====================================================================================================
    #region Campos privados y constructor
    // ====================================================================================================

    public LabelEntry() {
        InitializeComponent();
    }


    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region Propiedades
    // ====================================================================================================


    public string Text {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }
    public static readonly BindableProperty TextProperty =
        BindableProperty.CreateAttached("Text", typeof(string), typeof(LabelEntry), string.Empty);


    public string Value {
        get { return (string)GetValue(ValueProperty); }
        set { SetValue(ValueProperty, value); }
    }
    public static readonly BindableProperty ValueProperty =
        BindableProperty.CreateAttached("Value", typeof(string), typeof(LabelEntry), string.Empty, BindingMode.TwoWay);




    public bool ShowSeparator {
        get { return (bool)GetValue(ShowSeparatorProperty); }
        set { SetValue(ShowSeparatorProperty, value); }
    }
    public static readonly BindableProperty ShowSeparatorProperty =
        BindableProperty.CreateAttached("ShowSeparator", typeof(bool), typeof(LabelEntry), true);




    #endregion
    // ====================================================================================================



}