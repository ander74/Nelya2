#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;

namespace Nelya.Wpf.Converters;

public class EnumDisplayConverter : IValueConverter {

    object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        Enum myEnum = (Enum)value;
        if (myEnum == null) {
            return null;
        }
        string description = GetEnumDescription(myEnum);
        if (!string.IsNullOrEmpty(description)) {
            return description;
        }
        return myEnum.ToString();
    }

    object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => string.Empty;


    private string GetEnumDescription(Enum enumObj) {
        if (enumObj == null) {
            return string.Empty;
        }
        FieldInfo fieldInfo = enumObj.GetType().GetField(enumObj.ToString());

        object[] attribArray = fieldInfo.GetCustomAttributes(false);

        if (attribArray.Length == 0) {
            return enumObj.ToString();
        } else {
            DisplayAttribute attrib = attribArray[0] as DisplayAttribute;
            return attrib?.Name ?? enumObj.ToString();
        }
    }


}

