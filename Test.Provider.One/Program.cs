using Test.BI.Interfaces;
using Test.BI.Services;
using Test.Data.ProviderOne;
using Test.Providers.BI;
using Test.Providers.BI.Interfaces;
using Test.Providers.BI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IStatus, StatusService>();
builder.Services.AddScoped<IData<ProviderOneSearchResponse>, DataProviderOne>();
builder.Services.AddSingleton<DataRepository>();

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