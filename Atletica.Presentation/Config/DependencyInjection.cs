using Atletica.Application.Services;
using Atletica.Domain.Repositories;
using Atletica.Infrastructure.Data;
using Atletica.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Atletica.Presentation.Config
{
    public static class DependencyInjection
    {
        public static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Configuração do DbContext com MySQL
            // IMPORTANTE: Altere a connection string conforme seu ambiente
            var connectionString = "Server=localhost;Database=atletica_db;User=root;Password=;";
            
            services.AddDbContext<AtleticaDbContext>(options =>
                options.UseMySql(connectionString, 
                    ServerVersion.AutoDetect(connectionString)));

            // Repositórios
            services.AddScoped<ICargoRepository, CargoRepository>();
            services.AddScoped<IMembroRepository, MembroRepository>();
            services.AddScoped<ITarefaLimpezaRepository, TarefaLimpezaRepository>();
            services.AddScoped<IEventoRepository, EventoRepository>();

            // Serviços
            services.AddScoped<CargoService>();
            services.AddScoped<MembroService>();
            services.AddScoped<TarefaLimpezaService>();
            services.AddScoped<EventoService>();

            return services.BuildServiceProvider();
        }
    }
}
