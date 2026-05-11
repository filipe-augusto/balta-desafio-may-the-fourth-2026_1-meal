using Desafio_1.Core.Models;
using Microsoft.Extensions.AI;
using Microsoft.Agents.AI;
using Desafio_1.Core.Contracts;
using System.Text.Json;

namespace Desafio_1.Ai.Agentes;


internal class ServicoReceitaIA(IChatClient clienteChat) : IServicoReceitaIA
{

    private readonly IChatClient _clienteChat = clienteChat;

    public async Task<string> GerarSugestoesAsync(
    List<string> ingredientes,
    List<TempoLivre> janelasLivres)
    {
        var agente = new ChatClientAgent(
            _clienteChat,
            name: "AgenteReceitas",
            instructions:
            """
            Você é um especialista em receitas rápidas.

            Sua função:
            - Analisar ingredientes disponíveis
            - Cruzar com horários livres da agenda
            - Sugerir receitas compatíveis com o tempo disponível
            - Priorizar receitas rápidas e simples
            - Responder em português brasileiro
            """
        );

        var prompt =
        $"""
        Ingredientes disponíveis:
        {JsonSerializer.Serialize(ingredientes)}

        Horários livres:
        {JsonSerializer.Serialize(janelasLivres)}

        Sugira receitas adequadas para cada horário livre.
        """;

        var resposta = await agente.RunAsync(prompt);

        return resposta.ToString();
    }


}



