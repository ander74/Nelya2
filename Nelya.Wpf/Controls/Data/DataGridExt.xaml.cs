#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Nelya.Wpf.Controls.Data;


public partial class DataGridExt : DataGrid {


    // ====================================================================================================
    #region CAMPOS PRIVADOS Y CONSTRUCTOR
    // ====================================================================================================

    /// <summary>
    /// Propiedad que se pone a true la primera vez que se llama al método 'OnContextMenuOpening', para
    /// evitar que se añadan más de una vez los MenuItems de copiar y pegar al menú contextual.
    /// </summary>
    private bool contextMenuMerged = false;

    public DataGridExt() {
        InitializeComponent();

    }


    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region PROPIEDAD FILA ACTUAL
    // ====================================================================================================

    public int FilaActual {
        get => (int)GetValue(FilaActualProperty);
        set => SetValue(FilaActualProperty, value);
    }
    public static readonly DependencyProperty FilaActualProperty =
        DependencyProperty.Register("FilaActual", typeof(int), typeof(DataGridExt), new PropertyMetadata(-1));



    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region PROPIEDAD COLUMNA ACTUAL
    // ====================================================================================================

    public int ColumnaActual {
        get => (int)GetValue(ColumnaActualProperty);
        set => SetValue(ColumnaActualProperty, value);
    }
    public static readonly DependencyProperty ColumnaActualProperty =
        DependencyProperty.Register("ColumnaActual", typeof(int), typeof(DataGridExt), new FrameworkPropertyMetadata(-1, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region PROPIEDAD COMANDO DOBLE CLICK Y PARÁMETRO
    // ====================================================================================================

    public ICommand DobleClick {
        get => (ICommand)GetValue(DobleClickProperty);
        set => SetValue(DobleClickProperty, value);
    }
    public static readonly DependencyProperty DobleClickProperty =
        DependencyProperty.Register("DobleClick", typeof(ICommand), typeof(DataGridExt), new PropertyMetadata());


    public object DobleClickParametro {
        get => (object)GetValue(DobleClickParametroProperty);
        set => SetValue(DobleClickParametroProperty, value);
    }
    public static readonly DependencyProperty DobleClickParametroProperty =
        DependencyProperty.Register("DobleClickParametro", typeof(object), typeof(DataGridExt), new PropertyMetadata());


    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region PROPIEDAD ELEMENTO SELECCIONADO
    // ====================================================================================================

    public object ElementoSeleccionado {
        get => (object)GetValue(ElementoSeleccionadoProperty);
        set => SetValue(ElementoSeleccionadoProperty, value);
    }
    public static readonly DependencyProperty ElementoSeleccionadoProperty =
        DependencyProperty.Register("ElementoSeleccionado", typeof(object), typeof(DataGridExt), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region PROPIEDAD MERGE MENU CONTEXTUAL
    // ====================================================================================================

    public bool MergeMenuContextual {
        get => (bool)GetValue(MergeMenuContextualProperty);
        set => SetValue(MergeMenuContextualProperty, value);
    }
    public static readonly DependencyProperty MergeMenuContextualProperty =
        DependencyProperty.Register("MergeMenuContextual", typeof(bool), typeof(DataGridExt), new PropertyMetadata(true));


    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region PROPIEDADES IMAGEN COMANDO COPIAR Y PEGAR
    // ====================================================================================================

    public BitmapSource IconoComandoCopiar {
        get => (BitmapSource)GetValue(IconoComandoCopiarProperty);
        set => SetValue(IconoComandoCopiarProperty, value);
    }
    public static readonly DependencyProperty IconoComandoCopiarProperty =
        DependencyProperty.Register("IconoComandoCopiar", typeof(BitmapSource), typeof(DataGridExt), new PropertyMetadata());


    public BitmapSource IconoComandoPegar {
        get => (BitmapSource)GetValue(IconoComandoPegarProperty);
        set => SetValue(IconoComandoPegarProperty, value);
    }
    public static readonly DependencyProperty IconoComandoPegarProperty =
        DependencyProperty.Register("IconoComandoPegar", typeof(BitmapSource), typeof(DataGridExt), new PropertyMetadata());


    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region COMANDO ALTERNAR MODO SELECCION
    // ====================================================================================================

    // Comando
    private ICommand comandoAlternarModoSeleccion;
    public ICommand ComandoAlternarModoSeleccion {
        get {
            if (comandoAlternarModoSeleccion == null) comandoAlternarModoSeleccion = new RelayCommand(AlternarModoSeleccion);
            return comandoAlternarModoSeleccion;
        }
    }

    // Ejecución del comando
    private void AlternarModoSeleccion() {
        if (SelectionUnit == DataGridSelectionUnit.Cell) {
            SelectionUnit = DataGridSelectionUnit.FullRow;
        } else {
            SelectionUnit = DataGridSelectionUnit.Cell;
        }
    }

    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region COMANDO COPIAR
    // ====================================================================================================

    // Routed Command
    private ICommand cmdCopiar;
    public ICommand CmdCopiar {
        get {
            if (cmdCopiar == null) {
                cmdCopiar = new RoutedUICommand("Copiar", "CmdCopiar", typeof(DataGridExt), new InputGestureCollection { new KeyGesture(Key.C, ModifierKeys.Control) });
                this.CommandBindings.Add(new CommandBinding(cmdCopiar, Copiar, PuedeCopiar));
            }
            return cmdCopiar;
        }
    }
    // Relay Command
    private ICommand comandoCopiar;
    public ICommand ComandoCopiar {
        get {
            if (comandoCopiar == null) comandoCopiar = new RelayCommand<object>(p => CmdCopiar.Execute(p), p => CmdCopiar.CanExecute(p));
            return comandoCopiar;
        }
    }

    // Métodos Compartidos
    private void PuedeCopiar(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;// SelectedCells?.Count > 0;
    private void Copiar(object sender, ExecutedRoutedEventArgs e) {
        if (ApplicationCommands.Copy.CanExecute(null, this)) ApplicationCommands.Copy.Execute(null, this);
    }


    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region COMANDO PEGAR
    // ====================================================================================================

    // Routed Command
    private ICommand cmdPegar;
    public ICommand CmdPegar {
        get {
            if (cmdPegar == null) {
                cmdPegar = new RoutedUICommand("Pegar", "CmdPegar", typeof(DataGridExt), new InputGestureCollection { new KeyGesture(Key.V, ModifierKeys.Control) });
                this.CommandBindings.Add(new CommandBinding(cmdPegar, Pegar, PuedePegar));
            }
            return cmdPegar;
        }
    }

    // Relay Command
    private ICommand comandoPegar;
    public ICommand ComandoPegar {
        get {
            if (comandoPegar == null) comandoPegar = new RelayCommand<object>(p => CmdPegar.Execute(p), p => CmdPegar.CanExecute(p));
            return comandoPegar;
        }
    }

    // Métodos Compartidos
    private void PuedePegar(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = SelectedCells?.Count > 0 && IsReadOnly == false;
    private void Pegar(object sender, ExecutedRoutedEventArgs e) {
        // Si no hay texto en el portapapeles, salimos
        if (!Clipboard.ContainsText()) return;
        bool hayNuevaFila = false;
        ICollectionView cv = CollectionViewSource.GetDefaultView(Items);
        IEditableCollectionView iecv = cv as IEditableCollectionView;
        // Si hay más de una celda seleccionada copiamos el portapapeles en cada celda.
        if (this.SelectedCells.Count > 1) {
            foreach (var celda in this.SelectedCells) {
                var col = Columns.IndexOf(celda.Column);
                var fil = Items.IndexOf(celda.Item);
                // Si estamos en la última fila, añadimos una fila más.
                if (fil == Items.Count) {
                    if (!CanUserAddRows) continue;
                    if (iecv != null) {
                        hayNuevaFila = true;
                        iecv.AddNew();
                        iecv.CommitNew();
                    }
                }
                DataGridColumn column = ColumnFromDisplayIndex(col);
                column.OnPastingCellClipboardContent(celda.Item, Clipboard.GetText());
                if (hayNuevaFila) iecv.CommitNew();
            }
        } else {
            // Recuperamos las filas del portapapeles.
            List<string[]> portapapeles = parseClipboard();
            if (portapapeles == null) return;
            // Establecemos la fila y la columna actual.
            int filagrid = Items.IndexOf(CurrentItem);
            if (filagrid == -1) return;
            int columnagrid = Columns.IndexOf(CurrentColumn);
            // Iteramos por las filas del portapapeles.
            foreach (string[] fila in portapapeles) {
                // Si estamos en la última fila, añadimos una fila más.
                if (filagrid == Items.Count) {
                    if (!CanUserAddRows) continue;
                    if (iecv != null) {
                        hayNuevaFila = true;
                        iecv.AddNew();
                        iecv.CommitNew();
                    }
                }
                // Establecemos la columna inicial en la que se va a pegar.
                int columna = columnagrid;
                // Iteramos por cada campo de la fila del portapapeles
                foreach (string texto in fila) {
                    if (columna > Columns.Count - 1) continue;
                    DataGridColumn column = ColumnFromDisplayIndex(columna);
                    column.OnPastingCellClipboardContent(Items[filagrid], texto);
                    columna++;
                }
                filagrid++;
                if (hayNuevaFila) iecv.CommitNew();
            }
        }
        // Hacemos commit a la edición del datagrid.
        this.CommitEdit();
    }

    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region EVENTOS
    // ====================================================================================================

    protected override void OnSelectedCellsChanged(SelectedCellsChangedEventArgs e) {
        if (e.AddedCells != null && e.AddedCells.Count > 0) {
            var cell = e.AddedCells[0];
            if (!cell.IsValid) return;
            if (SelectedCells.Count == 1 && cell.Item.GetType().Name != "NamedObject") {
                ElementoSeleccionado = cell.Item;
            } else {
                ElementoSeleccionado = null;
            }
            ColumnaActual = cell.Column.DisplayIndex;
            FilaActual = Items.IndexOf(cell.Item);
        }
        base.OnSelectedCellsChanged(e);
    }


    protected override void OnPreviewKeyDown(KeyEventArgs e) {
        switch (e.Key) {
            case Key.Delete:
                if (SelectionUnit == DataGridSelectionUnit.FullRow) {
                    CurrentColumn?.OnPastingCellClipboardContent(Items[Items.IndexOf(CurrentItem)], string.Empty);
                } else {
                    foreach (DataGridCellInfo celda in SelectedCells) {
                        celda.Column?.OnPastingCellClipboardContent(celda.Item, string.Empty);
                    }
                }
                e.Handled = true;
                break;
            case Key.Up:
            case Key.Down:
                if (e.OriginalSource is TextBox) CommitEdit();
                break;
            case Key.V:
                if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control) {
                    if (CmdPegar.CanExecute(null)) CmdPegar.Execute(null);
                    e.Handled = true;
                }
                break;
        }
    }


    protected override void OnPreviewMouseDoubleClick(MouseButtonEventArgs e) {
        if (DobleClick?.CanExecute(DobleClickParametro) ?? false) {
            DobleClick.Execute(DobleClickParametro);
            e.Handled = true;
        }
        base.OnPreviewMouseDoubleClick(e);
    }


    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region MÉTODOS PRIVADOS
    // ====================================================================================================

    /// <summary>
    /// Lee el texto almacenado en el portapapeles y lo introduce en una lista de arrays de cadenas.
    /// De esta manera, se crea una tabla de valores de texto en la que la lista tiene las filas y el
    /// Array tiene las columnas.
    /// </summary>
    /// <returns>Lista de Arrays de cadenas.</returns>
    private List<string[]> parseClipboard() {
        if (!Clipboard.ContainsText()) return null;
        List<string[]> lista = new List<string[]>();
        string[] datos = Clipboard.GetText().Split("\n".ToCharArray());
        foreach (string texto in datos) {
            if (string.IsNullOrEmpty(texto)) continue;
            string[] fila = texto.Replace("\n", "").Replace("\r", "").Split("\t".ToCharArray());
            lista.Add(fila);
        }
        return lista;
    }

    #endregion
    // ====================================================================================================


    // ====================================================================================================
    #region MÉTODOS OVERRIDE
    // ====================================================================================================

    protected override void OnContextMenuOpening(ContextMenuEventArgs e) {
        if (MergeMenuContextual && !contextMenuMerged) {

            if (ContextMenu == null) {
                ContextMenu = new ContextMenu();
            } else {
                ContextMenu.Items.Add(new Separator());
            }

            ContextMenu.Items.Add(new MenuItem {
                Header = "Copiar",
                Command = CmdCopiar,
                Icon = new Image { Source = IconoComandoCopiar },
            });

            ContextMenu.Items.Add(new MenuItem {
                Header = "Pegar",
                Command = CmdPegar,
                Icon = new Image { Source = IconoComandoPegar },
            });
            contextMenuMerged = true;
        }
        base.OnContextMenuOpening(e);
    }


    #endregion
    // ====================================================================================================



}

