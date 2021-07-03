using ClinicApi.Models;
using Microsoft.Extensions.Configuration;

namespace ClinicApi.Providers
{
    public class DbContextProvider : IDbContextProvider
    {
        private readonly IConfiguration Configuration;
        private static MainDbContext mainDbContext;

        public DbContextProvider(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public MainDbContext GetDbContext()
        {
            if (mainDbContext == null)
            {
                mainDbContext = new MainDbContext(Configuration);
            }

            return mainDbContext;
        }
    }
}
