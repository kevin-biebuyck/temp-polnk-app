using System.Text.Json.Serialization;

namespace Polnk.App.Core.Models.CurriculumVitaes;

public class OtherCurriculumVitaeAnswer : CurriculumVitaeAnswer
{
    public override string AnswerId { get; } = $"Other-{Guid.NewGuid()}";

    public OtherCurriculumVitaeAnswer() { }
    [JsonConstructor]
    public OtherCurriculumVitaeAnswer(string answerId)
    {
        AnswerId = answerId;
    }

    [Newtonsoft.Json.JsonProperty("name"), JsonPropertyName("name")]
    public string? Name { get; set; }
    [Newtonsoft.Json.JsonProperty("level"), JsonPropertyName("level")]
    public Level? Level { get; set; }
}