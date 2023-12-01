#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using Nelya.Core.Helpers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Nelya.Wpf.Controls.FakeGrid;


public partial class FakeGridTimeFixedRow : Grid {


    // ====================================================================================================
    #region CAMPOS PRIVADOS Y CONSTRUCTOR
    // ====================================================================================================

    public FakeGridTimeFixedRow() {
        InitializeComponent();
        if (ShowValueColors) {
            if (Value.Ticks < 0) Foreground = Brushes.DarkRed;
            if (Value.Ticks == 0) Foreground = Brushes.DarkGray;
            if (Value.Ticks > 0) Foreground = Brushes.DarkGreen;
        }
        if (HideOnZero && Value == TimeSpan.Zero) {
            Visibility = Visibility.Collapsed;
        } else {
            Visibility = Visibility.Visible;
        }
        if (ShowInDecimal) {
            Valor = $"{Value.ToTexto()} ({Value.ToDecimal(2):0.00})";
        } else {
            Valor = Value.ToTexto();
        }
    }


    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region PROPIEDADES
    // ====================================================================================================


    public double FontSize {
        get => (double)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }
    public static readonly DependencyProperty FontSizeProperty =
        DependencyProperty.Register("FontSize", typeof(double), typeof(FakeGridTimeFixedRow), new PropertyMetadata(14d));


    public string Definition {
        get => (string)GetValue(DefinitionProperty);
        set => SetValue(DefinitionProperty, value);
    }
    public static readonly DependencyProperty DefinitionProperty =
        DependencyProperty.Register("Definition", typeof(string), typeof(FakeGridTimeFixedRow), new PropertyMetadata(string.Empty, null, CoerceDefinition));


    public TimeSpan Value {
        get => (TimeSpan)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(TimeSpan), typeof(FakeGridTimeFixedRow), new PropertyMetadata(TimeSpan.Zero, null, CoerceValue));


    public TextAlignment DefinitionAlignment {
        get => (TextAlignment)GetValue(DefinitionAlignmentProperty);
        set => SetValue(DefinitionAlignmentProperty, value);
    }
    public static readonly DependencyProperty DefinitionAlignmentProperty =
        DependencyProperty.Register("DefinitionAlignment", typeof(TextAlignment), typeof(FakeGridTimeFixedRow), new PropertyMetadata(TextAlignment.Left));


    public TextAlignment ValueAlignment {
        get => (TextAlignment)GetValue(ValueAlignmentProperty);
        set => SetValue(ValueAlignmentProperty, value);
    }
    public static readonly DependencyProperty ValueAlignmentProperty =
        DependencyProperty.Register("ValueAlignment", typeof(TextAlignment), typeof(FakeGridTimeFixedRow), new PropertyMetadata(TextAlignment.Right));


    public Brush Foreground {
        get => (Brush)GetValue(ForegroundProperty);
        set => SetValue(ForegroundProperty, value);
    }
    public static readonly DependencyProperty ForegroundProperty =
        DependencyProperty.Register("Foreground", typeof(Brush), typeof(FakeGridTimeFixedRow), new PropertyMetadata(Brushes.DarkGray));


    public FontWeight DefinitionWeight {
        get => (FontWeight)GetValue(DefinitionWeightProperty);
        set => SetValue(DefinitionWeightProperty, value);
    }
    public static readonly DependencyProperty DefinitionWeightProperty =
        DependencyProperty.Register("DefinitionWeight", typeof(FontWeight), typeof(FakeGridTimeFixedRow), new PropertyMetadata());


    public FontWeight ValueWeight {
        get => (FontWeight)GetValue(ValueWeightProperty);
        set => SetValue(ValueWeightProperty, value);
    }
    public static readonly DependencyProperty ValueWeightProperty =
        DependencyProperty.Register("ValueWeight", typeof(FontWeight), typeof(FakeGridTimeFixedRow), new PropertyMetadata());


    public bool HideOnZero {
        get => (bool)GetValue(HideOnZeroProperty);
        set => SetValue(HideOnZeroProperty, value);
    }
    public static readonly DependencyProperty HideOnZeroProperty =
        DependencyProperty.Register("HideOnZero", typeof(bool), typeof(FakeGridTimeFixedRow), new PropertyMetadata(true, null, CoerceHideOnZero));


    public string Valor {
        get => (string)GetValue(ValorProperty);
        set => SetValue(ValorProperty, value);
    }
    public static readonly DependencyProperty ValorProperty =
        DependencyProperty.Register("Valor", typeof(string), typeof(FakeGridTimeFixedRow), new PropertyMetadata(""));


    public bool ShowInDecimal {
        get => (bool)GetValue(ShowInDecimalProperty);
        set => SetValue(ShowInDecimalProperty, value);
    }
    public static readonly DependencyProperty ShowInDecimalProperty =
        DependencyProperty.Register("ShowInDecimal", typeof(bool), typeof(FakeGridTimeFixedRow), new PropertyMetadata(true));



    public bool ShowValueColors {
        get => (bool)GetValue(ShowValueColorsProperty);
        set => SetValue(ShowValueColorsProperty, value);
    }
    public static readonly DependencyProperty ShowValueColorsProperty =
        DependencyProperty.Register("ShowValueColors", typeof(bool), typeof(FakeGridTimeFixedRow), new PropertyMetadata(false));







    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region MÉTODOS PRIVADOS
    // ====================================================================================================

    public static object CoerceHideOnZero(DependencyObject d, object value) {
        TimeSpan valor = (TimeSpan)d.GetValue(ValueProperty);
        bool ocultar = (bool)value;
        if (ocultar && valor == TimeSpan.Zero) {
            d.SetValue(VisibilityProperty, Visibility.Collapsed);
        } else {
            d.SetValue(VisibilityProperty, Visibility.Visible);
        }
        return value;
    }


    public static object CoerceValue(DependencyObject d, object value) {
        TimeSpan hora = (TimeSpan)(value ?? TimeSpan.Zero);
        bool ocultar = (bool)d.GetValue(HideOnZeroProperty);
        bool verDecimal = (bool)d.GetValue(ShowInDecimalProperty);
        bool verColores = (bool)d.GetValue(ShowValueColorsProperty);
        if (verColores) {
            if (hora.Ticks < 0) d.SetValue(ForegroundProperty, Brushes.DarkRed);
            if (hora.Ticks == 0) d.SetValue(ForegroundProperty, Brushes.DarkGray);
            if (hora.Ticks > 0) d.SetValue(ForegroundProperty, Brushes.DarkGreen);
        }
        if (ocultar && hora == TimeSpan.Zero) {
            d.SetValue(VisibilityProperty, Visibility.Collapsed);
        } else {
            d.SetValue(VisibilityProperty, Visibility.Visible);
        }
        if (verDecimal) {
            d.SetValue(ValorProperty, $"{hora.ToTexto()} ({hora.ToDecimal(2):0.00})");
        } else {
            d.SetValue(ValorProperty, hora.ToTexto());
        }

        return value;
    }


    public static object CoerceDefinition(DependencyObject d, object value) {
        if (value is string texto) {
            return texto += $" {new string('.', 100)}";
        }
        return value;
    }



    #endregion
    // ====================================================================================================








}
