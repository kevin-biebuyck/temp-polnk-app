using System.Text.Json.Serialization;

namespace Polnk.App.Core.Models.CurriculumVitaes;

public class SoftwareCurriculumVitaeAnswer : CurriculumVitaeAnswer
{
    public const string Key = "Software";
    public override string AnswerId { get; } = $"{Key}-{Guid.NewGuid()}";

    public SoftwareCurriculumVitaeAnswer() { }
    [JsonConstructor]
    public SoftwareCurriculumVitaeAnswer(string answerId)
    {
        AnswerId = answerId;
    }

    [Newtonsoft.Json.JsonProperty("software"), JsonPropertyName("software")]
    public string? Software { get; set; }
    [Newtonsoft.Json.JsonProperty("level"), JsonPropertyName("level")]
    public Level? Level { get; set; }
}