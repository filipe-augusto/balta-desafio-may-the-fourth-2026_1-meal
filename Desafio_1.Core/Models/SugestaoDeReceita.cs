namespace Desafio_1.Core.Models;

public class SugestaoDeReceita
{
    public string Nome { get; set; } = string.Empty;
    public int PreparationMinutes { get; set; }
    public List<string> UsedIngredients { get; set; } = [];
    public string Instructions { get; set; } = string.Empty;
}
