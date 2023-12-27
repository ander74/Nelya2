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


    public string Detail {
        get { return (string)GetValue(DetailProperty); }
        set { SetValue(DetailProperty, value); }
    }
    public static readonly BindableProperty DetailProperty =
        BindableProperty.CreateAttached("Detail", typeof(string), typeof(LabelEntry), string.Empty);


    public string Value {
        get { return (string)GetValue(ValueProperty); }
        set { SetValue(ValueProperty, value); }
    }
    public static readonly BindableProperty ValueProperty =
        BindableProperty.CreateAttached("Value", typeof(string), typeof(LabelEntry), string.Empty, BindingMode.TwoWay);


    public Color TextColor {
        get { return (Color)GetValue(TextColorProperty); }
        set { SetValue(TextColorProperty, value); }
    }
    public static readonly BindableProperty TextColorProperty =
        BindableProperty.CreateAttached("TextColor", typeof(Color), typeof(LabelEntry), Colors.Black);


    public Color DetailColor {
        get { return (Color)GetValue(DetailColorProperty); }
        set { SetValue(DetailColorProperty, value); }
    }
    public static readonly BindableProperty DetailColorProperty =
        BindableProperty.CreateAttached("DetailColor", typeof(Color), typeof(LabelEntry), Colors.Black);


    public Color ValueColor {
        get { return (Color)GetValue(ValueColorProperty); }
        set { SetValue(ValueColorProperty, value); }
    }
    public static readonly BindableProperty ValueColorProperty =
        BindableProperty.CreateAttached("ValueColor", typeof(Color), typeof(LabelEntry), Colors.Black);


    public bool ShowSeparator {
        get { return (bool)GetValue(ShowSeparatorProperty); }
        set { SetValue(ShowSeparatorProperty, value); }
    }
    public static readonly BindableProperty ShowSeparatorProperty =
        BindableProperty.CreateAttached("ShowSeparator", typeof(bool), typeof(LabelEntry), true);




    #endregion
    // ====================================================================================================



}