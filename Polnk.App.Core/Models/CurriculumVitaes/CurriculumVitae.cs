using Newtonsoft.Json;

namespace Polnk.App.Core.Models.CurriculumVitaes;

public class CurriculumVitae
{
    
    public string? WholeVideoId { get; set; }

    // Key is answerId
    [JsonProperty("answers")]
    public Dictionary<string, CurriculumVitaeAnswer> Answers { get; set; } = new Dictionary<string, CurriculumVitaeAnswer>();

    /// <summary>
    /// Key is "Theme", value is ordered answers
    /// </summary>
    public ThemesOrder[] ThemesOrder { get; set; } = Array.Empty<ThemesOrder>();

}