using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cep.api.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace cep.api
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

            services.AddDbContext<CepDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("CepDbConnection"))
            );
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, CepDbContext cepContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            cepContext.Database.Migrate();
            cepContext.SeedData();
        }
    }
}
