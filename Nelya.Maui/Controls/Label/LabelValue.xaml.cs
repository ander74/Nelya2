#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using System.Windows.Input;

namespace Nelya.Maui.Controls.Label;


public partial class LabelValue : ContentView {

    // ====================================================================================================
    #region Campos privados y constructor
    // ====================================================================================================

    public LabelValue() {
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
        BindableProperty.CreateAttached("Text", typeof(string), typeof(LabelValue), string.Empty);


    public string Value {
        get { return (string)GetValue(ValueProperty); }
        set { SetValue(ValueProperty, value); }
    }
    public static readonly BindableProperty ValueProperty =
        BindableProperty.CreateAttached("Value", typeof(string), typeof(LabelValue), string.Empty, BindingMode.TwoWay);


    public bool ShowSeparator {
        get { return (bool)GetValue(ShowSeparatorProperty); }
        set { SetValue(ShowSeparatorProperty, value); }
    }
    public static readonly BindableProperty ShowSeparatorProperty =
        BindableProperty.CreateAttached("ShowSeparator", typeof(bool), typeof(LabelValue), true);


    public ICommand Command {
        get { return (ICommand)GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }
    public static readonly BindableProperty CommandProperty =
        BindableProperty.CreateAttached("Command", typeof(ICommand), typeof(LabelValue), default(ICommand),
            propertyChanging: (bindable, oldvalue, newvalue) => {
                var labelValue = (LabelValue)bindable;
                var oldcommand = (ICommand)oldvalue;
                if (oldcommand != null)
                    oldcommand.CanExecuteChanged -= labelValue.OnCommandCanExecuteChanged;
            }, propertyChanged: (bindable, oldvalue, newvalue) => {
                var labelValue = (LabelValue)bindable;
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
        BindableProperty.CreateAttached("CommandParameter", typeof(object), typeof(LabelValue), default(object),
            propertyChanged: (bindable, oldvalue, newvalue) => {
                var labelValue = (LabelValue)bindable;
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