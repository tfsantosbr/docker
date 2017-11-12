﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pedidos.API.Data.Context;

namespace Pedidos.API
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

            services.AddDbContext<PedidosDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("PedidosDbConnection"))
            );
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, PedidosDbContext pedidosDbContext)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();

            pedidosDbContext.Database.Migrate();
            pedidosDbContext.SeedData();
        }
    }
}