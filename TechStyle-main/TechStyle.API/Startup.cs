using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStyle.Dados;
using TechStyle.Dados.Repositorio;
using TechStyle.Dominio.Interface.Repositorios;
using TechStyle.Dominio.Interface.Services;
using TechStyle.Dominio.Repositorio;
using TechStyle.Dominio.Services;

namespace TechStyle.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TechStyle.API", Version = "v1" });
            });
            services.AddDbContext<Contexto>(
                options => options.UseSqlServer
                ("Server=DESKTOP-R9JFMSC\\SQLEXPRESS;Database=TechStyle;Trusted_Connection=True;MultipleActiveResultSets=true"));

            services.AddScoped<IBibliotecaRepositorio, BibliotecaRepositorio>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<ISegmentoRepositorio, SegmentoRepositorio>();
            services.AddScoped<IEstoqueRepositorio, EstoqueRepositorio>();
            services.AddScoped<IVendasRepositorio, VendasRepositorio>();
            services.AddScoped<IItemDeVendaRepositorio, ItemDeVendaRepositorio>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ISegmentoService, SegmentoService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<IVendasService, VendasService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechStyle.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
