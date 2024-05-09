using System.Text.Json.Serialization;

namespace Polnk.App.Core.Models.CurriculumVitaes;

public class ExperienceCurriculumVitaeAnswer : CurriculumVitaeAnswer
{
    public const string Key = "Experience";
    public override string AnswerId { get; } = $"{Key}-{Guid.NewGuid()}";

    public ExperienceCurriculumVitaeAnswer() { }
    [JsonConstructor]
    public ExperienceCurriculumVitaeAnswer(string answerId)
    {
        AnswerId = answerId;
    }

    [Newtonsoft.Json.JsonProperty("companyName"), JsonPropertyName("companyName")]
    public string? CompanyName { get; set; }
    [Newtonsoft.Json.JsonProperty("role"), JsonPropertyName("role")]
    public string? Role { get; set; }
    [Newtonsoft.Json.JsonProperty("from"), JsonPropertyName("from")]
    public DateOnly? From { get; set; }
    [Newtonsoft.Json.JsonProperty("to"), JsonPropertyName("to")]
    public DateOnly? To { get; set; }
}