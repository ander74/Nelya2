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


public partial class FakeGridAmountPriceFixedRow : Grid {


    // ====================================================================================================
    #region CAMPOS PRIVADOS Y CONSTRUCTOR
    // ====================================================================================================

    public FakeGridAmountPriceFixedRow() {
        InitializeComponent();
        if (ShowValueColors) {
            if (Price < 0m) Foreground = Brushes.DarkRed;
            if (Price == 0m) Foreground = Brushes.DarkGray;
            if (Price > 0m) Foreground = Brushes.DarkGreen;
        }
        if (HideOnZero && Price == 0m) {
            Visibility = Visibility.Collapsed;
        } else {
            Visibility = Visibility.Visible;
        }
        //if (IsMoney) {
        //    Valor = $"{Math.Round(Value, Decimales)} €";
        //} else {
        Valor = $"({Math.Round(Amount, Decimales)}) {Math.Round(Price, Decimales)} €";
        //}

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
        DependencyProperty.Register("FontSize", typeof(double), typeof(FakeGridAmountPriceFixedRow), new PropertyMetadata(14d));


    public string Definition {
        get => (string)GetValue(DefinitionProperty);
        set => SetValue(DefinitionProperty, value);
    }
    public static readonly DependencyProperty DefinitionProperty =
        DependencyProperty.Register("Definition", typeof(string), typeof(FakeGridAmountPriceFixedRow), new PropertyMetadata(string.Empty, null, CoerceDefinition));


    public decimal Amount {
        get => (decimal)GetValue(AmountProperty);
        set => SetValue(AmountProperty, value);
    }
    public static readonly DependencyProperty AmountProperty =
        DependencyProperty.Register("Amount", typeof(decimal), typeof(FakeGridAmountPriceFixedRow), new PropertyMetadata(0m, null, CoerceAmount));


    public decimal Price {
        get => (decimal)GetValue(PriceProperty);
        set => SetValue(PriceProperty, value);
    }
    public static readonly DependencyProperty PriceProperty =
        DependencyProperty.Register("Price", typeof(decimal), typeof(FakeGridAmountPriceFixedRow), new PropertyMetadata(0m, null, CoercePrice));


    public TextAlignment DefinitionAlignment {
        get => (TextAlignment)GetValue(DefinitionAlignmentProperty);
        set => SetValue(DefinitionAlignmentProperty, value);
    }
    public static readonly DependencyProperty DefinitionAlignmentProperty =
        DependencyProperty.Register("DefinitionAlignment", typeof(TextAlignment), typeof(FakeGridAmountPriceFixedRow), new PropertyMetadata(TextAlignment.Left));


    public TextAlignment ValueAlignment {
        get => (TextAlignment)GetValue(ValueAlignmentProperty);
        set => SetValue(ValueAlignmentProperty, value);
    }
    public static readonly DependencyProperty ValueAlignmentProperty =
        DependencyProperty.Register("ValueAlignment", typeof(TextAlignment), typeof(FakeGridAmountPriceFixedRow), new PropertyMetadata(TextAlignment.Right));


    public Brush Foreground {
        get => (Brush)GetValue(ForegroundProperty);
        set => SetValue(ForegroundProperty, value);
    }
    public static readonly DependencyProperty ForegroundProperty =
        DependencyProperty.Register("Foreground", typeof(Brush), typeof(FakeGridAmountPriceFixedRow), new PropertyMetadata(Brushes.DarkGray));


    public FontWeight DefinitionWeight {
        get => (FontWeight)GetValue(DefinitionWeightProperty);
        set => SetValue(DefinitionWeightProperty, value);
    }
    public static readonly DependencyProperty DefinitionWeightProperty =
        DependencyProperty.Register("DefinitionWeight", typeof(FontWeight), typeof(FakeGridAmountPriceFixedRow), new PropertyMetadata());


    public FontWeight ValueWeight {
        get => (FontWeight)GetValue(ValueWeightProperty);
        set => SetValue(ValueWeightProperty, value);
    }
    public static readonly DependencyProperty ValueWeightProperty =
        DependencyProperty.Register("ValueWeight", typeof(FontWeight), typeof(FakeGridAmountPriceFixedRow), new PropertyMetadata());


    public bool HideOnZero {
        get => (bool)GetValue(HideOnZeroProperty);
        set => SetValue(HideOnZeroProperty, value);
    }
    public static readonly DependencyProperty HideOnZeroProperty =
        DependencyProperty.Register("HideOnZero", typeof(bool), typeof(FakeGridAmountPriceFixedRow), new PropertyMetadata(true, null, CoerceHideOnZero));


    public string Valor {
        get => (string)GetValue(ValorProperty);
        set => SetValue(ValorProperty, value);
    }
    public static readonly DependencyProperty ValorProperty =
        DependencyProperty.Register("Valor", typeof(string), typeof(FakeGridAmountPriceFixedRow), new PropertyMetadata(string.Empty));


    public int Decimales {
        get => (int)GetValue(DecimalesProperty);
        set => SetValue(DecimalesProperty, value);
    }
    public static readonly DependencyProperty DecimalesProperty =
        DependencyProperty.Register("Decimales", typeof(int), typeof(FakeGridAmountPriceFixedRow), new PropertyMetadata(2));


    public bool ShowValueColors {
        get => (bool)GetValue(ShowValueColorsProperty);
        set => SetValue(ShowValueColorsProperty, value);
    }
    public static readonly DependencyProperty ShowValueColorsProperty =
        DependencyProperty.Register("ShowValueColors", typeof(bool), typeof(FakeGridAmountPriceFixedRow), new PropertyMetadata(false));







    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region MÉTODOS PRIVADOS
    // ====================================================================================================

    public static object CoerceHideOnZero(DependencyObject d, object value) {
        decimal cantidad = (decimal)d.GetValue(AmountProperty);
        decimal precio = (decimal)d.GetValue(PriceProperty);
        int decimales = (int)d.GetValue(DecimalesProperty);
        bool ocultar = (bool)value;
        if (ocultar && precio == 0m) {
            d.SetValue(VisibilityProperty, Visibility.Collapsed);
        } else {
            d.SetValue(VisibilityProperty, Visibility.Visible);
        }
        d.SetValue(ValorProperty, $"({Math.Round(cantidad, decimales)}) {Math.Round(precio, decimales)} €");
        return value;
    }


    public static object CoerceAmount(DependencyObject d, object value) {
        decimal cantidad = (decimal)value;
        decimal precio = (decimal)d.GetValue(PriceProperty);
        bool ocultar = (bool)d.GetValue(HideOnZeroProperty);
        int decimales = (int)d.GetValue(DecimalesProperty);
        bool verColores = (bool)d.GetValue(ShowValueColorsProperty);
        if (verColores) {
            if (precio < 0m) d.SetValue(ForegroundProperty, Brushes.DarkRed);
            if (precio == 0m) d.SetValue(ForegroundProperty, Brushes.DarkGray);
            if (precio > 0m) d.SetValue(ForegroundProperty, Brushes.DarkGreen);
        }
        if (ocultar && precio == 0m) {
            d.SetValue(VisibilityProperty, Visibility.Collapsed);
        } else {
            d.SetValue(VisibilityProperty, Visibility.Visible);
        }
        d.SetValue(ValorProperty, $"({Math.Round(cantidad, decimales)}) {Math.Round(precio, decimales)} €");
        return value;
    }


    public static object CoercePrice(DependencyObject d, object value) {
        decimal cantidad = (decimal)d.GetValue(AmountProperty);
        decimal precio = (decimal)value;
        bool ocultar = (bool)d.GetValue(HideOnZeroProperty);
        int decimales = (int)d.GetValue(DecimalesProperty);
        bool verColores = (bool)d.GetValue(ShowValueColorsProperty);
        if (verColores) {
            if (precio < 0m) d.SetValue(ForegroundProperty, Brushes.DarkRed);
            if (precio == 0m) d.SetValue(ForegroundProperty, Brushes.DarkGray);
            if (precio > 0m) d.SetValue(ForegroundProperty, Brushes.DarkGreen);
        }
        if (ocultar && precio == 0m) {
            d.SetValue(VisibilityProperty, Visibility.Collapsed);
        } else {
            d.SetValue(VisibilityProperty, Visibility.Visible);
        }
        d.SetValue(ValorProperty, $"({Math.Round(cantidad, decimales)}) {Math.Round(precio, decimales)} €");
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
