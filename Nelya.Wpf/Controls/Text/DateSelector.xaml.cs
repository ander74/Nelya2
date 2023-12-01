#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using System.Windows;
using System.Windows.Controls;

namespace Nelya.Wpf.Controls.Text;


public partial class DateSelector : UserControl {


    // ====================================================================================================
    #region CAMPOS PRIVADOS Y CONSTRUCTOR
    // ====================================================================================================

    public DateSelector() {
        InitializeComponent();
        DayVisibility = IsDayVisible ? Visibility.Visible : Visibility.Collapsed;
    }


    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region PROPIEDADES
    // ====================================================================================================


    public DateTime Fecha {
        get => (DateTime)GetValue(FechaProperty);
        set => SetValue(FechaProperty, value);
    }
    public static readonly DependencyProperty FechaProperty =
        DependencyProperty.Register("Fecha", typeof(DateTime), typeof(DateSelector), new PropertyMetadata(DateTime.Now));


    public Visibility DayVisibility {
        get => (Visibility)GetValue(DayVisibilityProperty);
        set => SetValue(DayVisibilityProperty, value);
    }
    public static readonly DependencyProperty DayVisibilityProperty =
        DependencyProperty.Register("DayVisibility", typeof(Visibility), typeof(DateSelector), new PropertyMetadata(Visibility.Visible));


    public bool IsDayVisible {
        get => (bool)GetValue(IsDayVisibleProperty);
        set => SetValue(IsDayVisibleProperty, value);
    }
    public static readonly DependencyProperty IsDayVisibleProperty =
        DependencyProperty.Register("IsDayVisible", typeof(bool), typeof(DateSelector), new PropertyMetadata(true, null, OnCoerceIsDayVisible));


    public CornerRadius CornerRadius {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }
    public static readonly DependencyProperty CornerRadiusProperty =
        DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(DateSelector), new PropertyMetadata(new CornerRadius(4)));





    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region MÉTODOS PRIVADOS
    // ====================================================================================================

    private static object OnCoerceIsDayVisible(DependencyObject d, object baseValue) {
        if (baseValue is bool v) {
            d.SetValue(DayVisibilityProperty, v ? Visibility.Visible : Visibility.Collapsed);
        }
        return baseValue;
    }




    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region EVENTOS
    // ====================================================================================================

    private void BtDiaAnterior_Click(object sender, RoutedEventArgs e) {
        Fecha = Fecha.AddDays(-1);
    }

    private void BtDiaSiguiente_Click(object sender, RoutedEventArgs e) {
        Fecha = Fecha.AddDays(1);
    }


    private void BtMesAnterior_Click(object sender, RoutedEventArgs e) {
        Fecha = Fecha.AddMonths(-1);
    }

    private void BtMesSiguiente_Click(object sender, RoutedEventArgs e) {
        Fecha = Fecha.AddMonths(1);
    }


    private void BtAñoAnterior_Click(object sender, RoutedEventArgs e) {
        Fecha = Fecha.AddYears(-1);
    }

    private void BtAñoSiguiente_Click(object sender, RoutedEventArgs e) {
        Fecha = Fecha.AddYears(1);
    }



    #endregion
    // ====================================================================================================


}
