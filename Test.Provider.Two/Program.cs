
using Test.BI.Interfaces;
using Test.BI.Services;
using Test.Data.ProviderOne;
using Test.Providers.BI.Interfaces;
using Test.Providers.BI.Services;
using Test.Providers.BI;

namespace Test.ProviderTwo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<IStatus, StatusService>();
            builder.Services.AddScoped<IData<ProviderTwoSearchResponse>, DataProviderTwo>();
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
        }
    }
}