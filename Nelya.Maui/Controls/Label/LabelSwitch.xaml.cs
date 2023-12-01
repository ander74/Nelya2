#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion

namespace Nelya.Maui.Controls.Label;


public partial class LabelSwitch : ContentView {

    // ====================================================================================================
    #region Campos privados y constructor
    // ====================================================================================================

    public LabelSwitch() {
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
        BindableProperty.CreateAttached("Text", typeof(string), typeof(LabelSwitch), string.Empty);


    public bool IsToggled {
        get { return (bool)GetValue(IsToggledProperty); }
        set { SetValue(IsToggledProperty, value); }
    }
    public static readonly BindableProperty IsToggledProperty =
        BindableProperty.CreateAttached("IsToggled", typeof(bool), typeof(LabelSwitch), false, BindingMode.TwoWay);




    public bool ShowSeparator {
        get { return (bool)GetValue(ShowSeparatorProperty); }
        set { SetValue(ShowSeparatorProperty, value); }
    }
    public static readonly BindableProperty ShowSeparatorProperty =
        BindableProperty.CreateAttached("ShowSeparator", typeof(bool), typeof(LabelSwitch), true);




    #endregion
    // ====================================================================================================





}