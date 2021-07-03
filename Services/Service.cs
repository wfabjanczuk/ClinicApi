using ClinicApi.Models;
using ClinicApi.Providers;

namespace ClinicApi.Services
{
    public class Service
    {
        protected readonly MainDbContext DbContext;

        public Service(IDbContextProvider dbContextProvider)
        {
            DbContext = dbContextProvider.GetDbContext();
        }
    }
}
