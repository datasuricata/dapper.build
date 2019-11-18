using Dapper.Build.Data;
using Dapper.Build.Data.Map.Base;
using Dapper.Build.Data.Repository.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Dapper.Build.IoC {
    public class Bootstrap {
        public static void Configure (IServiceCollection services) {

            services.AddScoped (typeof (DapperContext));

            services.AddTransient (typeof (IRepository<>), typeof (Repository<>));

            services.AddSingleton (new RegisterMappings ());
        }
    }
}