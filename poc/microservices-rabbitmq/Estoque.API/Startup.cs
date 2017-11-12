using Estoque.API.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Estoque.API
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
            services.AddMvc();

            services.AddDbContext<EstoqueDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("EstoqueDbConnection"))
            );
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, EstoqueDbContext estoqueDbContext)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();

            estoqueDbContext.Database.Migrate();
            estoqueDbContext.SeedData();
        }
    }
}