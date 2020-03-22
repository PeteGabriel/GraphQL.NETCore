using GraphApiNetCore.GraphQL;
using GraphApiNetCore.GraphQL.queries;
using GraphApiNetCore.GraphQL.types;
using GraphApiNetCore.Repository;
using GraphApiNetCore.Repository.entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GraphApiNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            // If using Kestrel:
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            
            services.AddDbContext<CarvedRockDbContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:CarvedRock"]));

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            
            services.AddTransient<IRepository, ProductRepository>();
            
            services.AddScoped<ProductQuery>();
            services.AddScoped<ProductGraphType>();
            services.AddScoped<CarvedRockSchema>();
            
            services.AddGraphQL(options =>
                {
                    options.EnableMetrics = true;
                    options.ExposeExceptions = true;
                })
                .AddGraphTypes(ServiceLifetime.Scoped);
        }
        
        public void Configure(IApplicationBuilder app, CarvedRockDbContext dbContext)
        {
            app.UseGraphQL<CarvedRockSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
        }
    }
}