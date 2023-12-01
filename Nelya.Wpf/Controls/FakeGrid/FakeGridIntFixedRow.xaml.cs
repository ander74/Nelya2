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


public partial class FakeGridIntFixedRow : Grid {


    // ====================================================================================================
    #region CAMPOS PRIVADOS Y CONSTRUCTOR
    // ====================================================================================================

    public FakeGridIntFixedRow() {
        InitializeComponent();
        if (ShowValueColors) {
            if (Value < 0) Foreground = Brushes.DarkRed;
            if (Value == 0) Foreground = Brushes.DarkGray;
            if (Value > 0) Foreground = Brushes.DarkGreen;
        }
        if (HideOnZero && Value == 0) {
            Visibility = Visibility.Collapsed;
        } else {
            Visibility = Visibility.Visible;
        }
        if (ShowSecondValue) {
            Valor = $"{Value}{Separador}{Value2}";
        } else {
            Valor = $"{Value}";
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
        DependencyProperty.Register("FontSize", typeof(double), typeof(FakeGridIntFixedRow), new PropertyMetadata(14d));


    public string Definition {
        get => (string)GetValue(DefinitionProperty);
        set => SetValue(DefinitionProperty, value);
    }
    public static readonly DependencyProperty DefinitionProperty =
        DependencyProperty.Register("Definition", typeof(string), typeof(FakeGridIntFixedRow), new PropertyMetadata(string.Empty, null, CoerceDefinition));


    public int Value {
        get => (int)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(int), typeof(FakeGridIntFixedRow), new PropertyMetadata(0, null, CoerceValue));


    public int Value2 {
        get => (int)GetValue(Value2Property);
        set => SetValue(Value2Property, value);
    }
    public static readonly DependencyProperty Value2Property =
        DependencyProperty.Register("Value2", typeof(int), typeof(FakeGridIntFixedRow), new PropertyMetadata(0, null, CoerceValue2));


    public TextAlignment DefinitionAlignment {
        get => (TextAlignment)GetValue(DefinitionAlignmentProperty);
        set => SetValue(DefinitionAlignmentProperty, value);
    }
    public static readonly DependencyProperty DefinitionAlignmentProperty =
        DependencyProperty.Register("DefinitionAlignment", typeof(TextAlignment), typeof(FakeGridIntFixedRow), new PropertyMetadata(TextAlignment.Left));


    public TextAlignment ValueAlignment {
        get => (TextAlignment)GetValue(ValueAlignmentProperty);
        set => SetValue(ValueAlignmentProperty, value);
    }
    public static readonly DependencyProperty ValueAlignmentProperty =
        DependencyProperty.Register("ValueAlignment", typeof(TextAlignment), typeof(FakeGridIntFixedRow), new PropertyMetadata(TextAlignment.Right));


    public Brush Foreground {
        get => (Brush)GetValue(ForegroundProperty);
        set => SetValue(ForegroundProperty, value);
    }
    public static readonly DependencyProperty ForegroundProperty =
        DependencyProperty.Register("Foreground", typeof(Brush), typeof(FakeGridIntFixedRow), new PropertyMetadata(Brushes.DarkGray));


    public FontWeight DefinitionWeight {
        get => (FontWeight)GetValue(DefinitionWeightProperty);
        set => SetValue(DefinitionWeightProperty, value);
    }
    public static readonly DependencyProperty DefinitionWeightProperty =
        DependencyProperty.Register("DefinitionWeight", typeof(FontWeight), typeof(FakeGridIntFixedRow), new PropertyMetadata());


    public FontWeight ValueWeight {
        get => (FontWeight)GetValue(ValueWeightProperty);
        set => SetValue(ValueWeightProperty, value);
    }
    public static readonly DependencyProperty ValueWeightProperty =
        DependencyProperty.Register("ValueWeight", typeof(FontWeight), typeof(FakeGridIntFixedRow), new PropertyMetadata());


    public bool HideOnZero {
        get => (bool)GetValue(HideOnZeroProperty);
        set => SetValue(HideOnZeroProperty, value);
    }
    public static readonly DependencyProperty HideOnZeroProperty =
        DependencyProperty.Register("HideOnZero", typeof(bool), typeof(FakeGridIntFixedRow), new PropertyMetadata(true, null, CoerceHideOnZero));


    public string Valor {
        get => (string)GetValue(ValorProperty);
        set => SetValue(ValorProperty, value);
    }
    public static readonly DependencyProperty ValorProperty =
        DependencyProperty.Register("Valor", typeof(string), typeof(FakeGridIntFixedRow), new PropertyMetadata(string.Empty));


    public bool ShowSecondValue {
        get => (bool)GetValue(ShowSecondValueProperty);
        set => SetValue(ShowSecondValueProperty, value);
    }
    public static readonly DependencyProperty ShowSecondValueProperty =
        DependencyProperty.Register("ShowSecondValue", typeof(bool), typeof(FakeGridIntFixedRow), new PropertyMetadata(false));


    public string Separador {
        get => (string)GetValue(SeparadorProperty);
        set => SetValue(SeparadorProperty, value);
    }

    // Using a DependencyProperty as the backing store for Separador.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty SeparadorProperty =
        DependencyProperty.Register("Separador", typeof(string), typeof(FakeGridIntFixedRow), new PropertyMetadata("/", null, CoerceSeparador));


    public bool ShowValueColors {
        get => (bool)GetValue(ShowValueColorsProperty);
        set => SetValue(ShowValueColorsProperty, value);
    }
    public static readonly DependencyProperty ShowValueColorsProperty =
        DependencyProperty.Register("ShowValueColors", typeof(bool), typeof(FakeGridIntFixedRow), new PropertyMetadata(false));








    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region MÉTODOS PRIVADOS
    // ====================================================================================================

    public static object CoerceHideOnZero(DependencyObject d, object value) {
        int numero = (int)d.GetValue(ValueProperty);
        int numero2 = (int)d.GetValue(Value2Property);
        bool ocultar = (bool)value;
        bool mostrarValue2 = (bool)d.GetValue(ShowSecondValueProperty);
        string separador = (string)d.GetValue(SeparadorProperty);
        if (ocultar && numero == 0) {
            d.SetValue(VisibilityProperty, Visibility.Collapsed);
        } else {
            d.SetValue(VisibilityProperty, Visibility.Visible);
        }
        if (mostrarValue2) {
            d.SetValue(ValorProperty, $"{numero}{separador}{numero2}");
        } else {
            d.SetValue(ValorProperty, $"{numero}");
        }
        return value;
    }


    public static object CoerceValue(DependencyObject d, object value) {
        int numero = (int)value;
        int numero2 = (int)d.GetValue(Value2Property);
        bool ocultar = (bool)d.GetValue(HideOnZeroProperty);
        bool mostrarValue2 = (bool)d.GetValue(ShowSecondValueProperty);
        string separador = (string)d.GetValue(SeparadorProperty);
        bool verColores = (bool)d.GetValue(ShowValueColorsProperty);
        if (verColores) {
            if (numero < 0) d.SetValue(ForegroundProperty, Brushes.DarkRed);
            if (numero == 0) d.SetValue(ForegroundProperty, Brushes.DarkGray);
            if (numero > 0) d.SetValue(ForegroundProperty, Brushes.DarkGreen);
        }
        if (ocultar && numero == 0) {
            d.SetValue(VisibilityProperty, Visibility.Collapsed);
        } else {
            d.SetValue(VisibilityProperty, Visibility.Visible);
        }
        if (mostrarValue2) {
            d.SetValue(ValorProperty, $"{numero}{separador}{numero2}");
        } else {
            d.SetValue(ValorProperty, $"{numero}");
        }
        return value;
    }


    public static object CoerceValue2(DependencyObject d, object value) {
        int numero2 = (int)value;
        int numero = (int)d.GetValue(ValueProperty);
        bool ocultar = (bool)d.GetValue(HideOnZeroProperty);
        bool mostrarValue2 = (bool)d.GetValue(ShowSecondValueProperty);
        string separador = (string)d.GetValue(SeparadorProperty);
        if (ocultar && numero2 == 0) {
            d.SetValue(VisibilityProperty, Visibility.Collapsed);
        } else {
            d.SetValue(VisibilityProperty, Visibility.Visible);
        }
        if (mostrarValue2) {
            d.SetValue(ValorProperty, $"{numero}{separador}{numero2}");
        } else {
            d.SetValue(ValorProperty, $"{numero}");
        }
        return value;
    }


    public static object CoerceSeparador(DependencyObject d, object value) {
        int numero = (int)d.GetValue(ValueProperty);
        int numero2 = (int)d.GetValue(Value2Property);
        bool ocultar = (bool)d.GetValue(HideOnZeroProperty);
        bool mostrarValue2 = (bool)d.GetValue(ShowSecondValueProperty);
        string separador = (string)value;
        if (ocultar && numero2 == 0) {
            d.SetValue(VisibilityProperty, Visibility.Collapsed);
        } else {
            d.SetValue(VisibilityProperty, Visibility.Visible);
        }
        if (mostrarValue2) {
            d.SetValue(ValorProperty, $"{numero}{separador}{numero2}");
        } else {
            d.SetValue(ValorProperty, $"{numero}");
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
