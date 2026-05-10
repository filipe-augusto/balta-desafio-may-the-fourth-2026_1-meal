using Desafio_1.Core.Models;

namespace Desafio_1.Core.Contracts
{
    public interface IServicoAgenda
    {
        Task<List<TempoLivre>> ObterJanelasLivresAsync(DateTime from, DateTime to);
    }
}
