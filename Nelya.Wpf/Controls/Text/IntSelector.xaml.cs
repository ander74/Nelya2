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


public partial class IntSelector : UserControl {


    // ====================================================================================================
    #region CAMPOS PRIVADOS Y CONSTRUCTOR
    // ====================================================================================================


    public IntSelector() {
        InitializeComponent();
    }


    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region PROPIEDADES
    // ====================================================================================================


    public int Numero {
        get => (int)GetValue(NumeroProperty);
        set => SetValue(NumeroProperty, value);
    }
    public static readonly DependencyProperty NumeroProperty =
        DependencyProperty.Register("Numero", typeof(int), typeof(IntSelector), new PropertyMetadata(0));


    public CornerRadius CornerRadius {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }
    public static readonly DependencyProperty CornerRadiusProperty =
        DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(IntSelector), new PropertyMetadata(new CornerRadius(4)));



    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region EVENTOS
    // ====================================================================================================

    private void BtAnterior_Click(object sender, RoutedEventArgs e) {
        Numero--;
    }

    private void BtSiguiente_Click(object sender, RoutedEventArgs e) {
        Numero++;
    }



    #endregion
    // ====================================================================================================



}

