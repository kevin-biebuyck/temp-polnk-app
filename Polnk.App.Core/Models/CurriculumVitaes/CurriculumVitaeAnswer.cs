using System.Text.Json.Serialization;

namespace Polnk.App.Core.Models.CurriculumVitaes;

[JsonConverter(typeof(CurriculumVitaeAnswerConverter)), Newtonsoft.Json.JsonConverter(typeof(CurriculumVitaeAnswerNewtonsoftConverter))]
public abstract class CurriculumVitaeAnswer
{
    [Newtonsoft.Json.JsonProperty("answerId"), JsonPropertyName("answerId")]
    public abstract string AnswerId { get; }

    [Newtonsoft.Json.JsonProperty("videoId"), JsonPropertyName("videoId")]
    public string? VideoId { get; set; }
}