#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using System.Windows.Input;

namespace Nelya.Maui.Controls.Label;


public partial class LabelDateValue : ContentView {

    // ====================================================================================================
    #region Campos privados y constructor
    // ====================================================================================================

    public LabelDateValue() {
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
        BindableProperty.CreateAttached("Text", typeof(string), typeof(LabelDateValue), string.Empty);


    public string Detail {
        get { return (string)GetValue(DetailProperty); }
        set { SetValue(DetailProperty, value); }
    }
    public static readonly BindableProperty DetailProperty =
        BindableProperty.CreateAttached("Detail", typeof(string), typeof(LabelDateValue), string.Empty);


    public DateTime Value {
        get { return (DateTime)GetValue(ValueProperty); }
        set { SetValue(ValueProperty, value); }
    }
    public static readonly BindableProperty ValueProperty =
        BindableProperty.CreateAttached("Value", typeof(DateTime), typeof(LabelDateValue), DateTime.Today, BindingMode.TwoWay);


    public Color TextColor {
        get { return (Color)GetValue(TextColorProperty); }
        set { SetValue(TextColorProperty, value); }
    }
    public static readonly BindableProperty TextColorProperty =
        BindableProperty.CreateAttached("TextColor", typeof(Color), typeof(LabelDateValue), Colors.Black);


    public Color DetailColor {
        get { return (Color)GetValue(DetailColorProperty); }
        set { SetValue(DetailColorProperty, value); }
    }
    public static readonly BindableProperty DetailColorProperty =
        BindableProperty.CreateAttached("DetailColor", typeof(Color), typeof(LabelDateValue), Colors.Black);


    public Color ValueColor {
        get { return (Color)GetValue(ValueColorProperty); }
        set { SetValue(ValueColorProperty, value); }
    }
    public static readonly BindableProperty ValueColorProperty =
        BindableProperty.CreateAttached("ValueColor", typeof(Color), typeof(LabelDateValue), Colors.Black);


    public bool ShowSeparator {
        get { return (bool)GetValue(ShowSeparatorProperty); }
        set { SetValue(ShowSeparatorProperty, value); }
    }
    public static readonly BindableProperty ShowSeparatorProperty =
        BindableProperty.CreateAttached("ShowSeparator", typeof(bool), typeof(LabelDateValue), true);


    public ICommand Command {
        get { return (ICommand)GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }
    public static readonly BindableProperty CommandProperty =
        BindableProperty.CreateAttached("Command", typeof(ICommand), typeof(LabelDateValue), default(ICommand),
            propertyChanging: (bindable, oldvalue, newvalue) => {
                var labelValue = (LabelDateValue)bindable;
                var oldcommand = (ICommand)oldvalue;
                if (oldcommand != null)
                    oldcommand.CanExecuteChanged -= labelValue.OnCommandCanExecuteChanged;
            }, propertyChanged: (bindable, oldvalue, newvalue) => {
                var labelValue = (LabelDateValue)bindable;
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
        BindableProperty.CreateAttached("CommandParameter", typeof(object), typeof(LabelDateValue), default(object),
            propertyChanged: (bindable, oldvalue, newvalue) => {
                var labelValue = (LabelDateValue)bindable;
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