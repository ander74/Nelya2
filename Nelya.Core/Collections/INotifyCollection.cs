#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using Nelya.Core.Collections.Specialized;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Nelya.Core.Collections;


public interface INotifyCollection<T> : INotifyCollectionChanged where T : INotifyPropertyChanged {

    event EventHandler<ItemChangedEventArgs<T>> ItemPropertyChanged;

}