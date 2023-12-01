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

namespace Nelya.Wpf.Controls.FakeGrid;


public partial class FakeGridRow : Grid {


    // ====================================================================================================
    #region CAMPOS PRIVADOS Y CONSTRUCTOR
    // ====================================================================================================

    public FakeGridRow() {
        InitializeComponent();
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
        DependencyProperty.Register("FontSize", typeof(double), typeof(FakeGridRow), new PropertyMetadata(14d));


    public string Definition {
        get => (string)GetValue(DefinitionProperty);
        set => SetValue(DefinitionProperty, value);
    }
    public static readonly DependencyProperty DefinitionProperty =
        DependencyProperty.Register("Definition", typeof(string), typeof(FakeGridRow), new PropertyMetadata());


    public string Value {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(string), typeof(FakeGridRow), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


    public TextAlignment DefinitionAlignment {
        get => (TextAlignment)GetValue(DefinitionAlignmentProperty);
        set => SetValue(DefinitionAlignmentProperty, value);
    }
    public static readonly DependencyProperty DefinitionAlignmentProperty =
        DependencyProperty.Register("DefinitionAlignment", typeof(TextAlignment), typeof(FakeGridRow), new PropertyMetadata(TextAlignment.Left));


    public HorizontalAlignment ValueAlignment {
        get => (HorizontalAlignment)GetValue(ValueAlignmentProperty);
        set => SetValue(ValueAlignmentProperty, value);
    }
    public static readonly DependencyProperty ValueAlignmentProperty =
        DependencyProperty.Register("ValueAlignment", typeof(HorizontalAlignment), typeof(FakeGridRow), new PropertyMetadata(HorizontalAlignment.Right));


    public Brush Foreground {
        get => (Brush)GetValue(ForegroundProperty);
        set => SetValue(ForegroundProperty, value);
    }
    public static readonly DependencyProperty ForegroundProperty =
        DependencyProperty.Register("Foreground", typeof(Brush), typeof(FakeGridRow), new PropertyMetadata(Brushes.DarkGray));


    public FontWeight DefinitionWeight {
        get => (FontWeight)GetValue(DefinitionWeightProperty);
        set => SetValue(DefinitionWeightProperty, value);
    }
    public static readonly DependencyProperty DefinitionWeightProperty =
        DependencyProperty.Register("DefinitionWeight", typeof(FontWeight), typeof(FakeGridRow), new PropertyMetadata());


    public FontWeight ValueWeight {
        get => (FontWeight)GetValue(ValueWeightProperty);
        set => SetValue(ValueWeightProperty, value);
    }
    public static readonly DependencyProperty ValueWeightProperty =
        DependencyProperty.Register("ValueWeight", typeof(FontWeight), typeof(FakeGridRow), new PropertyMetadata());


    public bool IsReadOnly {
        get => (bool)GetValue(IsReadOnlyProperty);
        set => SetValue(IsReadOnlyProperty, value);
    }
    public static readonly DependencyProperty IsReadOnlyProperty =
        DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(FakeGridRow), new PropertyMetadata(false));


    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region MÉTODOS PRIVADOS
    // ====================================================================================================




    #endregion
    // ====================================================================================================



    // ====================================================================================================
    #region EVENT HANDLERS
    // ====================================================================================================

    private void tbValue_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) {
        if (sender is TextBox tb) {
            tb.SelectAll();
        }
    }



    private void tbValue_PreviewMouseDown(object sender, MouseButtonEventArgs e) {
        if (sender is TextBox tb) {
            if (!tb.IsKeyboardFocusWithin) {
                e.Handled = true;
                tb.Focus();
            }

        }
    }

    private void tbValue_PreviewKeyDown(object sender, KeyEventArgs e) {
        if (sender is TextBox tb) {
            if (e.Key == Key.Enter) tb.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            if (e.Key == Key.Down) {
                tb.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                e.Handled = true;
            }
            if (e.Key == Key.Up) {
                tb.MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous));
                e.Handled = true;
            }
        }
    }




    #endregion
    // ====================================================================================================



}