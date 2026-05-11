using Desafio_1.Core.Contracts;
using Desafio_1.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_1.Infra.Servicos;

public class ServicoAgendaFake : IServicoAgenda
{
    public Task<List<TempoLivre>> ObterJanelasLivresAsync(
        DateTime dataInicio,
        DateTime dataFim)
    {
        var janelas = new List<TempoLivre>
        {
            new()
            {
                Inicio = DateTime.Today.AddHours(12),
                Fim = DateTime.Today.AddHours(12).AddMinutes(40)
            },
            new()
            {
                Inicio = DateTime.Today.AddHours(18),
                Fim = DateTime.Today.AddHours(19)
            }
        };

        return Task.FromResult(janelas);
    }
}