#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Nelya.Wpf.Controls.FakeGrid;


public partial class FakeGridDecimalFixedRow : Grid {


    // ====================================================================================================
    #region CAMPOS PRIVADOS Y CONSTRUCTOR
    // ====================================================================================================

    public FakeGridDecimalFixedRow() {
        InitializeComponent();
        if (ShowValueColors) {
            if (Value < 0m) Foreground = Brushes.DarkRed;
            if (Value == 0m) Foreground = Brushes.DarkGray;
            if (Value > 0m) Foreground = Brushes.DarkGreen;
        }
        if (HideOnZero && Value == 0m) {
            Visibility = Visibility.Collapsed;
        } else {
            Visibility = Visibility.Visible;
        }
        if (IsMoney) {
            Valor = $"{Math.Round(Value, Decimales)} €";
        } else {
            Valor = $"{Math.Round(Value, Decimales)}";
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
        DependencyProperty.Register("FontSize", typeof(double), typeof(FakeGridDecimalFixedRow), new PropertyMetadata(14d));


    public string Definition {
        get => (string)GetValue(DefinitionProperty);
        set => SetValue(DefinitionProperty, value);
    }
    public static readonly DependencyProperty DefinitionProperty =
        DependencyProperty.Register("Definition", typeof(string), typeof(FakeGridDecimalFixedRow), new PropertyMetadata(string.Empty, null, CoerceDefinition));


    public decimal Value {
        get => (decimal)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(decimal), typeof(FakeGridDecimalFixedRow), new PropertyMetadata(0m, null, CoerceValue));


    public TextAlignment DefinitionAlignment {
        get => (TextAlignment)GetValue(DefinitionAlignmentProperty);
        set => SetValue(DefinitionAlignmentProperty, value);
    }
    public static readonly DependencyProperty DefinitionAlignmentProperty =
        DependencyProperty.Register("DefinitionAlignment", typeof(TextAlignment), typeof(FakeGridDecimalFixedRow), new PropertyMetadata(TextAlignment.Left));


    public TextAlignment ValueAlignment {
        get => (TextAlignment)GetValue(ValueAlignmentProperty);
        set => SetValue(ValueAlignmentProperty, value);
    }
    public static readonly DependencyProperty ValueAlignmentProperty =
        DependencyProperty.Register("ValueAlignment", typeof(TextAlignment), typeof(FakeGridDecimalFixedRow), new PropertyMetadata(TextAlignment.Right));


    public Brush Foreground {
        get => (Brush)GetValue(ForegroundProperty);
        set => SetValue(ForegroundProperty, value);
    }
    public static readonly DependencyProperty ForegroundProperty =
        DependencyProperty.Register("Foreground", typeof(Brush), typeof(FakeGridDecimalFixedRow), new PropertyMetadata(Brushes.DarkGray));


    public FontWeight DefinitionWeight {
        get => (FontWeight)GetValue(DefinitionWeightProperty);
        set => SetValue(DefinitionWeightProperty, value);
    }
    public static readonly DependencyProperty DefinitionWeightProperty =
        DependencyProperty.Register("DefinitionWeight", typeof(FontWeight), typeof(FakeGridDecimalFixedRow), new PropertyMetadata());


    public FontWeight ValueWeight {
        get => (FontWeight)GetValue(ValueWeightProperty);
        set => SetValue(ValueWeightProperty, value);
    }
    public static readonly DependencyProperty ValueWeightProperty =
        DependencyProperty.Register("ValueWeight", typeof(FontWeight), typeof(FakeGridDecimalFixedRow), new PropertyMetadata());


    public bool HideOnZero {
        get => (bool)GetValue(HideOnZeroProperty);
        set => SetValue(HideOnZeroProperty, value);
    }
    public static readonly DependencyProperty HideOnZeroProperty =
        DependencyProperty.Register("HideOnZero", typeof(bool), typeof(FakeGridDecimalFixedRow), new PropertyMetadata(true, null, CoerceHideOnZero));


    public string Valor {
        get => (string)GetValue(ValorProperty);
        set => SetValue(ValorProperty, value);
    }
    public static readonly DependencyProperty ValorProperty =
        DependencyProperty.Register("Valor", typeof(string), typeof(FakeGridDecimalFixedRow), new PropertyMetadata(string.Empty));



    public bool IsMoney {
        get => (bool)GetValue(IsMoneyProperty);
        set => SetValue(IsMoneyProperty, value);
    }
    public static readonly DependencyProperty IsMoneyProperty =
        DependencyProperty.Register("IsMoney", typeof(bool), typeof(FakeGridDecimalFixedRow), new PropertyMetadata(false));


    public int Decimales {
        get => (int)GetValue(DecimalesProperty);
        set => SetValue(DecimalesProperty, value);
    }
    public static readonly DependencyProperty DecimalesProperty =
        DependencyProperty.Register("Decimales", typeof(int), typeof(FakeGridDecimalFixedRow), new PropertyMetadata(2));


    public bool ShowValueColors {
        get => (bool)GetValue(ShowValueColorsProperty);
        set => SetValue(ShowValueColorsProperty, value);
    }
    public static readonly DependencyProperty ShowValueColorsProperty =
        DependencyProperty.Register("ShowValueColors", typeof(bool), typeof(FakeGridDecimalFixedRow), new PropertyMetadata(false));







    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region MÉTODOS PRIVADOS
    // ====================================================================================================

    public static object CoerceHideOnZero(DependencyObject d, object value) {
        decimal numero = (decimal)d.GetValue(ValueProperty);
        int decimales = (int)d.GetValue(DecimalesProperty);
        bool ocultar = (bool)value;
        bool isMoney = (bool)d.GetValue(IsMoneyProperty);
        if (ocultar && numero == 0m) {
            d.SetValue(VisibilityProperty, Visibility.Collapsed);
        } else {
            d.SetValue(VisibilityProperty, Visibility.Visible);
        }
        if (isMoney) {
            d.SetValue(ValorProperty, $"{Math.Round(numero, decimales)} €");
        } else {
            d.SetValue(ValorProperty, $"{Math.Round(numero, decimales)}");
        }
        return value;
    }


    public static object CoerceValue(DependencyObject d, object value) {
        decimal numero = (decimal)value;
        bool ocultar = (bool)d.GetValue(HideOnZeroProperty);
        int decimales = (int)d.GetValue(DecimalesProperty);
        bool isMoney = (bool)d.GetValue(IsMoneyProperty);
        bool verColores = (bool)d.GetValue(ShowValueColorsProperty);
        if (verColores) {
            if (numero < 0m) d.SetValue(ForegroundProperty, Brushes.DarkRed);
            if (numero == 0m) d.SetValue(ForegroundProperty, Brushes.DarkGray);
            if (numero > 0m) d.SetValue(ForegroundProperty, Brushes.DarkGreen);
        }
        if (ocultar && numero == 0m) {
            d.SetValue(VisibilityProperty, Visibility.Collapsed);
        } else {
            d.SetValue(VisibilityProperty, Visibility.Visible);
        }
        if (isMoney) {
            d.SetValue(ValorProperty, $"{Math.Round(numero, decimales)} €");
        } else {
            d.SetValue(ValorProperty, $"{Math.Round(numero, decimales)}");
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
