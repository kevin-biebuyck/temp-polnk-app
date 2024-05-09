using System.Text.Json.Serialization;

namespace Polnk.App.Core.Models.CurriculumVitaes;

public class EducationCurriculumVitaeAnswer : CurriculumVitaeAnswer
{
    public const string Key = "Education";
    public override string AnswerId { get; } = $"{Key}-{Guid.NewGuid()}";

    public EducationCurriculumVitaeAnswer() { }
    [JsonConstructor]
    public EducationCurriculumVitaeAnswer(string answerId)
    {
        AnswerId = answerId;
    }

    [Newtonsoft.Json.JsonProperty("schoolName"), JsonPropertyName("schoolName")]
    public string? SchoolName { get; set; }
    [Newtonsoft.Json.JsonProperty("degree"), JsonPropertyName("degree")]
    public Degree? Degree { get; set; }
    [Newtonsoft.Json.JsonProperty("from"), JsonPropertyName("from")]
    public DateOnly? From { get; set; }
    [Newtonsoft.Json.JsonProperty("to"), JsonPropertyName("to")]
    public DateOnly? To { get; set; }
}