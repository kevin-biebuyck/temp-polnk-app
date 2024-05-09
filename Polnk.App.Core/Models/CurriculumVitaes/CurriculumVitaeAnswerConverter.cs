using System.Text.Json;
using System.Text.Json.Serialization;

namespace Polnk.App.Core.Models.CurriculumVitaes;

public class CurriculumVitaeAnswerConverter : JsonConverter<CurriculumVitaeAnswer>
{
    public override CurriculumVitaeAnswer? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException("Expected StartObject token.");
        }

        using var jsonDoc = JsonDocument.ParseValue(ref reader);
        if (!jsonDoc.RootElement.TryGetProperty("AnswerId", out var answerIdElement) && !jsonDoc.RootElement.TryGetProperty("answerId", out answerIdElement))
        {
            throw new JsonException("Expected 'AnswerId' property.");
        }

        var answerId = answerIdElement.GetString();
        var answerKey = answerId?.Split('-')[0];

        CurriculumVitaeAnswer? result = answerKey switch
        {
            SelfPresentationCurriculumVitaeAnswer.Key => JsonSerializer.Deserialize<SelfPresentationCurriculumVitaeAnswer>(jsonDoc.RootElement.GetRawText(), options),
            EducationCurriculumVitaeAnswer.Key => JsonSerializer.Deserialize<EducationCurriculumVitaeAnswer>(jsonDoc.RootElement.GetRawText(), options),
            ExperienceCurriculumVitaeAnswer.Key => JsonSerializer.Deserialize<ExperienceCurriculumVitaeAnswer>(jsonDoc.RootElement.GetRawText(), options),
            LanguageCurriculumVitaeAnswer.Key => JsonSerializer.Deserialize<LanguageCurriculumVitaeAnswer>(jsonDoc.RootElement.GetRawText(), options),
            SoftwareCurriculumVitaeAnswer.Key => JsonSerializer.Deserialize<SoftwareCurriculumVitaeAnswer>(jsonDoc.RootElement.GetRawText(), options),
            SkillCurriculumVitaeAnswer.Key => JsonSerializer.Deserialize<SkillCurriculumVitaeAnswer>(jsonDoc.RootElement.GetRawText(), options),
            _ => JsonSerializer.Deserialize<OtherCurriculumVitaeAnswer>(jsonDoc.RootElement.GetRawText(), options)
        };

        return result ?? throw new JsonException("Unable to determine the correct CurriculumVitaeAnswer subclass.");
    }

    public override void Write(Utf8JsonWriter writer, CurriculumVitaeAnswer value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}