#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion

using System.Windows.Input;

namespace Nelya.Maui.Controls.Label;


public partial class LabelTimeValue : ContentView {

    // ====================================================================================================
    #region Campos privados y constructor
    // ====================================================================================================

    public LabelTimeValue() {
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
        BindableProperty.CreateAttached("Text", typeof(string), typeof(LabelTimeValue), string.Empty);


    public string Detail {
        get { return (string)GetValue(DetailProperty); }
        set { SetValue(DetailProperty, value); }
    }
    public static readonly BindableProperty DetailProperty =
        BindableProperty.CreateAttached("Detail", typeof(string), typeof(LabelTimeValue), string.Empty);


    public TimeSpan Value {
        get { return (TimeSpan)GetValue(ValueProperty); }
        set { SetValue(ValueProperty, value); }
    }
    public static readonly BindableProperty ValueProperty =
        BindableProperty.CreateAttached("Value", typeof(TimeSpan), typeof(LabelTimeValue), TimeSpan.Zero, BindingMode.TwoWay);


    public Color TextColor {
        get { return (Color)GetValue(TextColorProperty); }
        set { SetValue(TextColorProperty, value); }
    }
    public static readonly BindableProperty TextColorProperty =
        BindableProperty.CreateAttached("TextColor", typeof(Color), typeof(LabelTimeValue), Colors.Black);


    public Color DetailColor {
        get { return (Color)GetValue(DetailColorProperty); }
        set { SetValue(DetailColorProperty, value); }
    }
    public static readonly BindableProperty DetailColorProperty =
        BindableProperty.CreateAttached("DetailColor", typeof(Color), typeof(LabelTimeValue), Colors.Black);


    public Color ValueColor {
        get { return (Color)GetValue(ValueColorProperty); }
        set { SetValue(ValueColorProperty, value); }
    }
    public static readonly BindableProperty ValueColorProperty =
        BindableProperty.CreateAttached("ValueColor", typeof(Color), typeof(LabelTimeValue), Colors.Black);


    public bool ShowSeparator {
        get { return (bool)GetValue(ShowSeparatorProperty); }
        set { SetValue(ShowSeparatorProperty, value); }
    }
    public static readonly BindableProperty ShowSeparatorProperty =
        BindableProperty.CreateAttached("ShowSeparator", typeof(bool), typeof(LabelTimeValue), true);


    public ICommand Command {
        get { return (ICommand)GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }
    public static readonly BindableProperty CommandProperty =
        BindableProperty.CreateAttached("Command", typeof(ICommand), typeof(LabelTimeValue), default(ICommand),
            propertyChanging: (bindable, oldvalue, newvalue) => {
                var labelValue = (LabelTimeValue)bindable;
                var oldcommand = (ICommand)oldvalue;
                if (oldcommand != null)
                    oldcommand.CanExecuteChanged -= labelValue.OnCommandCanExecuteChanged;
            }, propertyChanged: (bindable, oldvalue, newvalue) => {
                var labelValue = (LabelTimeValue)bindable;
                var newcommand = (ICommand)newvalue;
                if (newcommand != null) {
                    labelValue.IsEnabled = newcommand.CanExecute(labelValue.CommandParameter);
                    newcommand.CanExecuteChanged += labelValue.OnCommandCanExecuteChanged;
                }
            });


    public object CommandParameter {
        get { return GetValue(CommandParameterProperty); }
        set { SetValue(CommandParameterProperty, value); }
    }
    public static readonly BindableProperty CommandParameterProperty =
        BindableProperty.CreateAttached("CommandParameter", typeof(object), typeof(LabelTimeValue), default(object),
            propertyChanged: (bindable, oldvalue, newvalue) => {
                var labelValue = (LabelTimeValue)bindable;
                if (labelValue.Command != null) {
                    labelValue.IsEnabled = labelValue.Command.CanExecute(newvalue);
                }
            });




    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region Métodos privados
    // ====================================================================================================


    private void OnCommandCanExecuteChanged(object sender, EventArgs eventArgs) {
        IsEnabled = Command.CanExecute(CommandParameter);
    }


    #endregion
    // ====================================================================================================


}