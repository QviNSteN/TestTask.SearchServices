using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net;
using System.Runtime;
using Test.BI.Interfaces;
using Test.General;
using Test.SearchService.AutoMapperProfiles;
using Test.SearchService.BI.Services;
using Test.SearchService.Data;
using static Test.SearchService.Data.Provider;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISearchService, SearchService>()
            .AddScoped<IStatus, SearchService>();

builder.Services.AddHttpClient<Provider>()
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        var handler = new HttpClientHandler()
        {
            AutomaticDecompression = DecompressionMethods.GZip
        };

        if (builder.Environment.IsDevelopment())
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

        return handler;

    });
builder.Services.AddSingleton<ILogger, ConsoleLogger>();
builder.Services.AddAutoMapper(automapper =>
{
    automapper.AddCollectionMappers();
}, typeof(SearchProfile));

var providers = builder.Configuration.GetSection("Providers").Get<List<Provider.Data>>();

builder.Services.AddScoped<Provider.Data>();

foreach (var data in providers)
{
        builder.Services.AddScoped(sp => new Provider(
        httpClient: sp.GetRequiredService<HttpClient>(),
        mapper: sp.GetRequiredService<IMapper>(),
        logger: sp.GetRequiredService<ILogger>(),
        data: data));
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
