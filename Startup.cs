using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using graphql_dotnetcore.Data;
using graphql_dotnetcore.GraphQL;
using graphql_dotnetcore.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace graphql_dotnetcore
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookStoreDbContext>(options =>
                options.UseSqlServer(_config["ConnectionStrings:BookStore"]));

            services.AddScoped<AuthorRepository>();
            services.AddScoped<BookRepository>();

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(
                s.GetRequiredService));
            services.AddScoped<BookStoreSchema>();

            services.AddGraphQL(o => { o.ExposeExceptions = true; })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddDataLoader();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, BookStoreDbContext bookStoreDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL<BookStoreSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            bookStoreDbContext.Seed();
        }
    }
}
