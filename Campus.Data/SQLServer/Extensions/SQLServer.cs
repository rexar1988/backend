using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Campus.Data.SQLServer;

namespace Campus.SQLServer
{
    public static class SQLServer
    {
        public static IServiceCollection SQLServerInit(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<CampusContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
