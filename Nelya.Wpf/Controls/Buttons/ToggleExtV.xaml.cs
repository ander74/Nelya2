#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Nelya.Wpf.Controls.Buttons;


public partial class ToggleExtV : ToggleButton {


    // ====================================================================================================
    #region CAMPOS PRIVADOS Y CONSTRUCTOR
    // ====================================================================================================

    public ToggleExtV() {
        InitializeComponent();
        TitleVisibility = (string.IsNullOrEmpty(Title)) ? Visibility.Collapsed : Visibility.Visible;
        IconFontTextVisibility = (string.IsNullOrEmpty(IconFontText)) ? Visibility.Collapsed : Visibility.Visible;
    }


    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region PROPIEDADES
    // ====================================================================================================

    public string Title {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register("Title", typeof(string), typeof(ToggleExtV), new PropertyMetadata(null, null, OnCoerceTitle));


    public string IconFontText {
        get => (string)GetValue(IconFontTextProperty);
        set => SetValue(IconFontTextProperty, value);
    }
    public static readonly DependencyProperty IconFontTextProperty =
        DependencyProperty.Register("IconFontText", typeof(string), typeof(ToggleExtV), new PropertyMetadata(null, null, OnCoerceIconFontText));


    private Visibility IconFontTextVisibility {
        get => (Visibility)GetValue(IconFontTextVisibilityProperty);
        set => SetValue(IconFontTextVisibilityProperty, value);
    }
    private static readonly DependencyProperty IconFontTextVisibilityProperty =
        DependencyProperty.Register("IconFontTextVisibility", typeof(Visibility), typeof(ToggleExtV), new PropertyMetadata(Visibility.Visible));


    private Visibility TitleVisibility {
        get => (Visibility)GetValue(TitleVisibilityProperty);
        set => SetValue(TitleVisibilityProperty, value);
    }
    private static readonly DependencyProperty TitleVisibilityProperty =
        DependencyProperty.Register("TitleVisibility", typeof(Visibility), typeof(ToggleExtV), new PropertyMetadata(Visibility.Visible));


    public CornerRadius CornerRadius {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }
    public static readonly DependencyProperty CornerRadiusProperty =
        DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ToggleExtV), new PropertyMetadata(new CornerRadius(2)));


    public Brush OnMouseBrush {
        get => (Brush)GetValue(OnMouseBrushProperty);
        set => SetValue(OnMouseBrushProperty, value);
    }
    public static readonly DependencyProperty OnMouseBrushProperty =
        DependencyProperty.Register("OnMouseBrush", typeof(Brush), typeof(ToggleExtV), new PropertyMetadata());


    public Brush OnPressBrush {
        get => (Brush)GetValue(OnPressBrushProperty);
        set => SetValue(OnPressBrushProperty, value);
    }
    public static readonly DependencyProperty OnPressBrushProperty =
        DependencyProperty.Register("OnPressBrush", typeof(Brush), typeof(ToggleExtV), new PropertyMetadata(Brushes.OldLace));


    public Brush CheckedBrush {
        get => (Brush)GetValue(CheckedBrushProperty);
        set => SetValue(CheckedBrushProperty, value);
    }
    public static readonly DependencyProperty CheckedBrushProperty =
        DependencyProperty.Register("CheckedBrush", typeof(Brush), typeof(ToggleExtV), new PropertyMetadata());


    public Brush CheckedBackground {
        get => (Brush)GetValue(CheckedBackgroundProperty);
        set => SetValue(CheckedBackgroundProperty, value);
    }
    public static readonly DependencyProperty CheckedBackgroundProperty =
        DependencyProperty.Register("CheckedBackground", typeof(Brush), typeof(ToggleExtV), new PropertyMetadata(Brushes.Azure));


    public FontFamily IconFontFamily {
        get => (FontFamily)GetValue(IconFontFamilyProperty);
        set => SetValue(IconFontFamilyProperty, value);
    }
    public static readonly DependencyProperty IconFontFamilyProperty =
        DependencyProperty.Register("IconFontFamily", typeof(FontFamily), typeof(ToggleExtV), new PropertyMetadata(null));


    public double IconFontSize {
        get => (double)GetValue(IconFontSizeProperty);
        set => SetValue(IconFontSizeProperty, value);
    }
    public static readonly DependencyProperty IconFontSizeProperty =
        DependencyProperty.Register("IconFontSize", typeof(double), typeof(ToggleExtV), new PropertyMetadata(24d));


    public Brush IconFontColor {
        get => (Brush)GetValue(IconFontColorProperty);
        set => SetValue(IconFontColorProperty, value);
    }
    public static readonly DependencyProperty IconFontColorProperty =
        DependencyProperty.Register("IconFontColor", typeof(Brush), typeof(ToggleExtV), new PropertyMetadata(Brushes.DimGray));


    private Thickness IconFontMargin {
        get => (Thickness)GetValue(IconFontMarginProperty);
        set => SetValue(IconFontMarginProperty, value);
    }
    private static readonly DependencyProperty IconFontMarginProperty =
        DependencyProperty.Register("IconFontMargin", typeof(Thickness), typeof(ToggleExtV),
            new PropertyMetadata(new Thickness(4, 0, 4, 0)));


    private Thickness IconTextMargin {
        get => (Thickness)GetValue(IconTextMarginProperty);
        set => SetValue(IconTextMarginProperty, value);
    }
    private static readonly DependencyProperty IconTextMarginProperty =
        DependencyProperty.Register("IconTextMargin", typeof(Thickness), typeof(ToggleExtV),
            new PropertyMetadata(new Thickness(4, 0, 4, 0)));


    public int IconSeparation {
        get => (int)GetValue(IconSeparationProperty);
        set => SetValue(IconSeparationProperty, value);
    }
    public static readonly DependencyProperty IconSeparationProperty =
        DependencyProperty.Register("IconSeparation", typeof(int), typeof(ToggleExtV), new PropertyMetadata(8, null, OnCoerceIconSeparation));



    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region MÉTODOS PRIVADOS
    // ====================================================================================================

    private static object OnCoerceTitle(DependencyObject d, object baseValue) {
        if (baseValue == null) {
            d.SetValue(TitleVisibilityProperty, Visibility.Collapsed);
        } else {
            d.SetValue(TitleVisibilityProperty, Visibility.Visible);
        }
        return baseValue;
    }

    private static object OnCoerceIconFontText(DependencyObject d, object baseValue) {
        if (baseValue == null) {
            d.SetValue(IconFontTextVisibilityProperty, Visibility.Collapsed);
        } else {
            d.SetValue(IconFontTextVisibilityProperty, Visibility.Visible);
        }
        return baseValue;
    }


    private static object OnCoerceIconSeparation(DependencyObject d, object baseValue) {
        if (baseValue is int separacion) {
            d.SetValue(IconFontMarginProperty, new Thickness(0, 0, separacion, 0));
            d.SetValue(IconTextMarginProperty, new Thickness(separacion, 0, 0, 0));
        } else {
            d.SetValue(IconFontMarginProperty, new Thickness(0, 0, 4, 0));
            d.SetValue(IconTextMarginProperty, new Thickness(4, 0, 0, 0));
        }
        return baseValue;
    }

    #endregion
    // ====================================================================================================



}