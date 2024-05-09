using System.Text.Json.Serialization;

namespace Polnk.App.Core.Models.CurriculumVitaes;

public class LanguageCurriculumVitaeAnswer : CurriculumVitaeAnswer
{
    public const string Key = "Language";
    public override string AnswerId { get; } = $"{Key}-{Guid.NewGuid()}";

    public LanguageCurriculumVitaeAnswer() { }
    [JsonConstructor]
    public LanguageCurriculumVitaeAnswer(string answerId)
    {
        AnswerId = answerId;
    }

    [Newtonsoft.Json.JsonProperty("language"), JsonPropertyName("language")]
    public string? Language { get; set; }
    [Newtonsoft.Json.JsonProperty("level"), JsonPropertyName("level")]
    public Level? Level { get; set; }
}