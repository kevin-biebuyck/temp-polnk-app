using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Polnk.App.Core.Models.CurriculumVitaes;

public class CurriculumVitaeAnswerNewtonsoftConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(CurriculumVitaeAnswer);
    }

    public override bool CanWrite => false;

    public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        var jsonObject = JObject.Load(reader);

        return System.Text.Json.JsonSerializer.Deserialize<CurriculumVitaeAnswer>(jsonObject.ToString())!;

    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }

}