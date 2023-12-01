#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Nelya.Core.Json.Converters;


public class TimeSpanJsonConverter : JsonConverter<TimeSpan> {


    public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        if (TimeSpan.TryParse(reader.GetString(), out TimeSpan value)) {
            return value;
        }
        return TimeSpan.MaxValue;
    }


    public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options) {
        if (value == TimeSpan.MaxValue) {
            writer.WriteStringValue("");
        } else {
            writer.WriteStringValue(value.ToString());
        }
    }

}
