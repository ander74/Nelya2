#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Nelya.Wpf.Controls.Text;


public partial class TextBoxExt : TextBox {


    // ====================================================================================================
    #region CAMPOS PRIVADOS Y CONSTRUCTOR
    // ====================================================================================================

    public TextBoxExt() {
        InitializeComponent();
        HeaderVisibility = (string.IsNullOrEmpty(Header)) ? Visibility.Collapsed : Visibility.Visible;
    }


    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region PROPIEDADES
    // ====================================================================================================

    public string Header {
        get => (string)GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }
    public static readonly DependencyProperty HeaderProperty =
        DependencyProperty.Register("Header", typeof(string), typeof(TextBoxExt), new PropertyMetadata(null, null, OnCoerceHeader));


    public Brush ColorHeader {
        get => (Brush)GetValue(ColorHeaderProperty);
        set => SetValue(ColorHeaderProperty, value);
    }
    public static readonly DependencyProperty ColorHeaderProperty =
        DependencyProperty.Register("ColorHeader", typeof(Brush), typeof(TextBoxExt), new PropertyMetadata(Brushes.Black));


    public double HeaderFontSize {
        get => (double)GetValue(HeaderFontSizeProperty);
        set => SetValue(HeaderFontSizeProperty, value);
    }
    public static readonly DependencyProperty HeaderFontSizeProperty =
        DependencyProperty.Register("HeaderFontSize", typeof(double), typeof(TextBoxExt), new PropertyMetadata(12d));


    public FontWeight HeaderFontWeight {
        get => (FontWeight)GetValue(HeaderFontWeightProperty);
        set => SetValue(HeaderFontWeightProperty, value);
    }
    public static readonly DependencyProperty HeaderFontWeightProperty =
        DependencyProperty.Register("HeaderFontWeight", typeof(FontWeight), typeof(TextBoxExt), new PropertyMetadata(FontWeights.Normal));


    public HorizontalAlignment HeaderHAlign {
        get => (HorizontalAlignment)GetValue(HeaderHAlignProperty);
        set => SetValue(HeaderHAlignProperty, value);
    }
    public static readonly DependencyProperty HeaderHAlignProperty =
        DependencyProperty.Register("HeaderHAlign", typeof(HorizontalAlignment), typeof(TextBoxExt), new PropertyMetadata(HorizontalAlignment.Left));


    public int HeaderSpacing {
        get => (int)GetValue(HeaderSpacingProperty);
        set => SetValue(HeaderSpacingProperty, value);
    }
    public static readonly DependencyProperty HeaderSpacingProperty =
        DependencyProperty.Register("HeaderSpacing", typeof(int), typeof(TextBoxExt), new PropertyMetadata(4, null, OnCoerceHeaderSpacing));


    private Thickness HeaderMargin {
        get => (Thickness)GetValue(HeaderMarginProperty);
        set => SetValue(HeaderMarginProperty, value);
    }
    private static readonly DependencyProperty HeaderMarginProperty =
        DependencyProperty.Register("HeaderMargin", typeof(Thickness), typeof(TextBoxExt), new PropertyMetadata(new Thickness(0, 0, 0, 4)));


    private Visibility HeaderVisibility {
        get => (Visibility)GetValue(HeaderVisibilityProperty);
        set => SetValue(HeaderVisibilityProperty, value);
    }
    private static readonly DependencyProperty HeaderVisibilityProperty =
        DependencyProperty.Register("HeaderVisibility", typeof(Visibility), typeof(TextBoxExt), new PropertyMetadata(Visibility.Visible));


    public ICommand ClickCommand {
        get => (ICommand)GetValue(ClickCommandProperty);
        set => SetValue(ClickCommandProperty, value);
    }
    public static readonly DependencyProperty ClickCommandProperty =
        DependencyProperty.Register("ClickCommand", typeof(ICommand), typeof(TextBoxExt), new PropertyMetadata());


    public object ClickCommandParameter {
        get => (object)GetValue(ClickCommandParameterProperty);
        set => SetValue(ClickCommandParameterProperty, value);
    }
    public static readonly DependencyProperty ClickCommandParameterProperty =
        DependencyProperty.Register("ClickCommandParameter", typeof(object), typeof(TextBoxExt), new PropertyMetadata());


    public bool SelectAllOnFocus {
        get => (bool)GetValue(SelectAllOnFocusProperty);
        set => SetValue(SelectAllOnFocusProperty, value);
    }
    public static readonly DependencyProperty SelectAllOnFocusProperty =
        DependencyProperty.Register("SelectAllOnFocus", typeof(bool), typeof(TextBoxExt), new PropertyMetadata(true));






    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region MÉTODOS OVERRIDE
    // ====================================================================================================

    protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e) {
        base.OnGotKeyboardFocus(e);
        if (SelectAllOnFocus) SelectAll();
    }


    protected override void OnPreviewMouseDown(MouseButtonEventArgs e) {
        base.OnPreviewMouseDown(e);
        if (!IsKeyboardFocusWithin) {
            e.Handled = true;
            Focus();
        }
    }


    protected override void OnKeyDown(KeyEventArgs e) {
        base.OnKeyDown(e);
        if (e.Key == Key.Enter) MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
    }


    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region MÉTODOS PRIVADOS
    // ====================================================================================================

    private static object OnCoerceHeaderSpacing(DependencyObject d, object baseValue) {
        if (baseValue is int separacion) {
            d.SetValue(HeaderMarginProperty, new Thickness(0, 0, 0, separacion));
        } else {
            d.SetValue(HeaderMarginProperty, new Thickness(0, 0, 0, 4));
        }
        return baseValue;
    }

    private static object OnCoerceHeader(DependencyObject d, object baseValue) {
        if (string.IsNullOrEmpty(baseValue as string)) {
            d.SetValue(HeaderVisibilityProperty, Visibility.Collapsed);
        } else {
            d.SetValue(HeaderVisibilityProperty, Visibility.Visible);
        }
        return baseValue;
    }

    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region EVENTOS
    // ====================================================================================================

    protected override void OnMouseDown(MouseButtonEventArgs e) {
        if (ClickCommand?.CanExecute(ClickCommandParameter) ?? false) {
            ClickCommand.Execute(ClickCommandParameter);
            e.Handled = true;
        }
        base.OnMouseDown(e);
    }


    protected override void OnGotFocus(RoutedEventArgs e) {
        if (ClickCommand?.CanExecute(ClickCommandParameter) ?? false) {
            ClickCommand.Execute(ClickCommandParameter);
            e.Handled = true;
        }
        base.OnGotFocus(e);
    }

    #endregion
    // ====================================================================================================





}
