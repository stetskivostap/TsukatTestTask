using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TsukatTestTask.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<UserContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
