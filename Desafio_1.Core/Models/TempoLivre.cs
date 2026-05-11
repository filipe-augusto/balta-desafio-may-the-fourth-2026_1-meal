namespace Desafio_1.Core.Models;

public class TempoLivre
{
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }

    public int DuracaoMinutos => (int)(Fim - Inicio).TotalMinutes;
}
