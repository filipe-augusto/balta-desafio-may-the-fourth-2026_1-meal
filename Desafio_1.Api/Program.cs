using Desafio_1.Ai.Agentes;
using Desafio_1.Core.Contracts;
using Desafio_1.Infra.Servicos;
using Microsoft.Extensions.AI;
using OpenAI.Chat;

var builder = WebApplication.CreateBuilder(args);

var token = "CHAVE";

var clienteOpenAi = new ChatClient("gpt-4o-mini", token);

var clienteChat = clienteOpenAi.AsIChatClient();

builder.Services.AddSingleton<IChatClient>(clienteChat);

builder.Services.AddScoped<IServicoAgenda, ServicoAgendaFake>();
builder.Services.AddScoped<IServicoReceitaIA, ServicoReceitaIA>();

var app = builder.Build();

app.MapGet("/", () => "API funcionando");

app.MapPost("/receitas/sugerir",
async (
    RequisicaoSugestaoReceita requisicao,
    IServicoAgenda servicoAgenda,
    IServicoReceitaIA servicoReceitaIA) =>
{
    var janelasLivres = await servicoAgenda.ObterJanelasLivresAsync(
        DateTime.Today,
        DateTime.Today.AddDays(1));

    var resultado = await servicoReceitaIA.GerarSugestoesAsync(
        requisicao.Ingredientes,
        janelasLivres);

    return Results.Ok(resultado);
});

app.Run();

public class RequisicaoSugestaoReceita
{
    public List<string> Ingredientes { get; set; } = [];
}