using ClinicApi.Models;
using ClinicApi.Providers;

namespace ClinicApi.Mappers
{
    public class Mapper
    {
        protected readonly MainDbContext DbContext;

        public Mapper(IDbContextProvider dbContextProvider)
        {
            DbContext = dbContextProvider.getDbContext();
        }
    }
}
