using Desafio_1.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_1.Core.Contracts;

public interface IServicoReceitaIA
{
    Task<string> GerarSugestoesAsync(
        List<string> ingredientes,
        List<TempoLivre> janelasLivres);
}
