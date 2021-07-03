using ClinicApi.Models;
using Microsoft.Extensions.Configuration;

namespace ClinicApi.Providers
{
    public class DbContextProvider : IDbContextProvider
    {
        private readonly IConfiguration Configuration;

        public DbContextProvider(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public MainDbContext getDbContext()
        {
            return new MainDbContext(Configuration);
        }
    }
}
