namespace Polnk.App.Core.Models.CurriculumVitaes;

public class ThemesOrder(string theme, string[] answersOrder)
{
    public string Theme { get; } = theme;
    public string[] AnswersOrder { get; } = answersOrder;
}