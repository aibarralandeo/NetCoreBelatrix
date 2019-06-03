using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Belatrix.WebApi.Repository.Postgresql.Services
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddPostgreSqlServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IBelatrixDbContext, BelatrixDbContext>();

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.AddEntityFrameworkNpgsql().AddDbContext<BelatrixDbContext>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("postgresql"))).BuildServiceProvider();
            return services;
        }
    }
}
