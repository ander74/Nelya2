#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Nelya.Core.Json.Converters;


public class FullDateTimeJsonConverter : JsonConverter<DateTime> {

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        var txt = reader.GetString();
        if (DateTime.TryParse(reader.GetString(), CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime value)) {
            return value;
        }
        return DateTime.MaxValue.Date;
    }


    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString("yyyy-MM-dd HH:mm"));

}