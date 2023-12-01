#region COPYRIGHT
// ===============================================
//     Copyright 2024 - Nelya 2.0 - A. Herrero    
// -----------------------------------------------
//  Vea el archivo Licencia.txt para más detalles 
// ===============================================
#endregion
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Nelya.Core.Json.Converters;


public class ColorJsonConverter : JsonConverter<Color> {

    public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        //if (int.TryParse(reader.GetString(), out int value)) {
        return Color.FromArgb(reader.GetInt32());
        //}
        //return Color.Black;
    }


    public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options) {
        writer.WriteNumberValue(value.ToArgb());
    }


}
