using GraphApiNetCore.GraphQL;
using GraphApiNetCore.GraphQL.queries;
using GraphApiNetCore.GraphQL.types;
using GraphApiNetCore.Mdlware;
using GraphApiNetCore.Repository;
using GraphApiNetCore.Repository.entities;
using GraphApiNetCore.Repository.impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;

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

            services.AddDbContext<CarvedRockDbContext>(options => options.UseSqlite("Data Source=carvedrock.db"));
            
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            
            services.AddTransient<IRepository<Product>, ProductRepository>();
            services.AddTransient<IRepository<ProductReview>, ProductReviewRepository>();
            
            services.AddScoped<ProductQuery>();
            services.AddScoped<ProductGraphType>();
            services.AddScoped<CarvedRockSchema>();
            
            services.AddGraphQL(options =>
                {
                    options.EnableMetrics = true;
                    options.ExposeExceptions = true;
                })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddDataLoader();
        }
        
        public void Configure(IApplicationBuilder app)
        {
            app.UseGraphQL<CarvedRockSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
        }
    }
}