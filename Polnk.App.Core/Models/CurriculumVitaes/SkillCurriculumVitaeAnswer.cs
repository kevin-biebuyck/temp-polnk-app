using System.Text.Json.Serialization;

namespace Polnk.App.Core.Models.CurriculumVitaes;

public class SkillCurriculumVitaeAnswer : CurriculumVitaeAnswer
{
    public const string Key = "Skill";
    public override string AnswerId { get; } = $"{Key}-{Guid.NewGuid()}";

    public SkillCurriculumVitaeAnswer() { }
    [JsonConstructor]
    public SkillCurriculumVitaeAnswer(string answerId)
    {
        AnswerId = answerId;
    }

    [Newtonsoft.Json.JsonProperty("skill"), JsonPropertyName("skill")]
    public string? Skill { get; set; }
    [Newtonsoft.Json.JsonProperty("level"), JsonPropertyName("level")]
    public Level? Level { get; set; }
}