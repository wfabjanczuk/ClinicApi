using ClinicApi.Models;

namespace ClinicApi.Providers
{
    public interface IDbContextProvider
    {
        public MainDbContext getDbContext();
    }
}
