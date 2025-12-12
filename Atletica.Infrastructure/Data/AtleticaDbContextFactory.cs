using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Atletica.Infrastructure.Data
{
    /// <summary>
    /// Factory para criar DbContext em design-time (migrations)
    /// </summary>
    public class AtleticaDbContextFactory : IDesignTimeDbContextFactory<AtleticaDbContext>
    {
        public AtleticaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AtleticaDbContext>();
            
            // Connection string padrão para design-time
            // IMPORTANTE: Ajuste conforme seu ambiente
            var connectionString = "Server=localhost;Database=atletica_db;User=root;Password=root;";
            
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new AtleticaDbContext(optionsBuilder.Options);
        }
    }
}
