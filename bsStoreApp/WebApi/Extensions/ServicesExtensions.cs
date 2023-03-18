using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contracts;

namespace WebApi.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) => services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
            // bundan sonra yapılması gereken bunu ihtiyacımız olan yerde enjekte etmek



        // metodu program.cs üserinde çağırmamız gerekiyor. 
        public static void ConfigureRepositoryManger(this IServiceCollection services)=>
            services.AddScoped<IRepositoryManager,RepositoryManger>();

        public static void ConfigureServiceyManger(this IServiceCollection services)=>
            services.AddScoped<IServiceManager,ServiceManager>();

    }
}
 