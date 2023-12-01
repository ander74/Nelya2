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

namespace Nelya.Wpf.Controls.Text;


public partial class TileButton : Button {

    // ====================================================================================================
    #region CAMPOS PRIVADOS Y CONSTRUCTOR
    // ====================================================================================================

    public TileButton() {
        InitializeComponent();
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
        DependencyProperty.Register("Title", typeof(string), typeof(TileButton), new PropertyMetadata());


    public string IconFontText {
        get => (string)GetValue(IconFontTextProperty);
        set => SetValue(IconFontTextProperty, value);
    }
    public static readonly DependencyProperty IconFontTextProperty =
        DependencyProperty.Register("IconFontText", typeof(string), typeof(TileButton), new PropertyMetadata());


    public Brush OnMouseBrush {
        get => (Brush)GetValue(OnMouseBrushProperty);
        set => SetValue(OnMouseBrushProperty, value);
    }
    public static readonly DependencyProperty OnMouseBrushProperty =
        DependencyProperty.Register("OnMouseBrush", typeof(Brush), typeof(TileButton), new PropertyMetadata(Brushes.SandyBrown));


    public Brush OnPressBrush {
        get => (Brush)GetValue(OnPressBrushProperty);
        set => SetValue(OnPressBrushProperty, value);
    }
    public static readonly DependencyProperty OnPressBrushProperty =
        DependencyProperty.Register("OnPressBrush", typeof(Brush), typeof(TileButton), new PropertyMetadata(Brushes.OldLace));


    public ImageSource UrlSource {
        get => (ImageSource)GetValue(UrlSourceProperty);
        set => SetValue(UrlSourceProperty, value);
    }
    public static readonly DependencyProperty UrlSourceProperty =
        DependencyProperty.Register("UrlSource", typeof(ImageSource), typeof(TileButton), new PropertyMetadata());


    public double AnchoImagen {
        get => (double)GetValue(AnchoImagenProperty);
        set => SetValue(AnchoImagenProperty, value);
    }
    public static readonly DependencyProperty AnchoImagenProperty =
        DependencyProperty.Register("AnchoImagen", typeof(double), typeof(TileButton), new PropertyMetadata(double.NaN));


    public double AltoImagen {
        get => (double)GetValue(AltoImagenProperty);
        set => SetValue(AltoImagenProperty, value);
    }
    public static readonly DependencyProperty AltoImagenProperty =
        DependencyProperty.Register("AltoImagen", typeof(double), typeof(TileButton), new PropertyMetadata(double.NaN));


    public double ImageOpacity {
        get => (double)GetValue(ImageOpacityProperty);
        set => SetValue(ImageOpacityProperty, value);
    }
    public static readonly DependencyProperty ImageOpacityProperty =
        DependencyProperty.Register("ImageOpacity", typeof(double), typeof(TileButton), new PropertyMetadata(1d));


    public CornerRadius CornerRadius {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }
    public static readonly DependencyProperty CornerRadiusProperty =
        DependencyProperty.Register("CornerRadius", typeof(CornerRadius),
            typeof(TileButton), new PropertyMetadata(new CornerRadius(0, 0, 4, 4)));



    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region MÉTODOS PRIVADOS
    // ====================================================================================================


    #endregion
    // ====================================================================================================


}
