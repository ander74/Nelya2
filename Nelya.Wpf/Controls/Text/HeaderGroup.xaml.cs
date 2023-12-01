#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace Nelya.Wpf.Controls.Text;


[ContentProperty("Contenido")]
public partial class HeaderGroup : UserControl {


    // ====================================================================================================
    #region CAMPOS PRIVADOS Y CONSTRUCTOR
    // ====================================================================================================

    public HeaderGroup() {
        InitializeComponent();
    }


    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region PROPIEDADES
    // ====================================================================================================


    public object Header {
        get => GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }
    public static readonly DependencyProperty HeaderProperty =
        DependencyProperty.Register("Header", typeof(object), typeof(HeaderGroup), new PropertyMetadata());


    public object Contenido {
        get => GetValue(ContenidoProperty);
        set => SetValue(ContenidoProperty, value);
    }
    public static readonly DependencyProperty ContenidoProperty =
        DependencyProperty.Register("Contenido", typeof(object), typeof(HeaderGroup), new PropertyMetadata());


    public Brush HeaderForeground {
        get => (Brush)GetValue(HeaderForegroundProperty);
        set => SetValue(HeaderForegroundProperty, value);
    }
    public static readonly DependencyProperty HeaderForegroundProperty =
        DependencyProperty.Register("HeaderForeground", typeof(Brush), typeof(HeaderGroup), new PropertyMetadata());



    public Brush HeaderBackground {
        get => (Brush)GetValue(HeaderBackgroundProperty);
        set => SetValue(HeaderBackgroundProperty, value);
    }
    public static readonly DependencyProperty HeaderBackgroundProperty =
        DependencyProperty.Register("HeaderBackground", typeof(Brush), typeof(HeaderGroup), new PropertyMetadata());


    public HorizontalAlignment HeaderHAlign {
        get => (HorizontalAlignment)GetValue(HeaderHAlignProperty);
        set => SetValue(HeaderHAlignProperty, value);
    }
    public static readonly DependencyProperty HeaderHAlignProperty =
        DependencyProperty.Register("HeaderHAlign", typeof(HorizontalAlignment), typeof(HeaderGroup), new PropertyMetadata(HorizontalAlignment.Center));


    public int HeaderFontSize {
        get => (int)GetValue(HeaderFontSizeProperty);
        set => SetValue(HeaderFontSizeProperty, value);
    }
    public static readonly DependencyProperty HeaderFontSizeProperty =
        DependencyProperty.Register("HeaderFontSize", typeof(int), typeof(HeaderGroup), new PropertyMetadata(16));


    #endregion
    // ====================================================================================================




}
