using AutoMapper;

using Library.Repo.SqlServer;
using Library.Repo.SqlServer.DBModelCliente;
using Library.Repo.SqlServer.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.Pattern.EF.EFCore;
using Repository.Pattern.EF.Entities;
using Repository.Pattern.EF.Repositories;
using System;

namespace Apis
{
    public class Startup

    {
        private IConfiguration configuration;

        public Startup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DBLibraryContext>(
            options => options
                      .UseSqlServer(configuration.GetConnectionString("Conexion2")));

            services.AddControllers();
            services.AddScoped<IUnitOfWorks, UnitOfWorks>();
            services.AddScoped<IArticuloRepository, ArticuloRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();


            //Para enviar datos de tipo XML
            //services.AddMvc()
            //.AddMvcOptions(o => o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()));

            //Autenticacion
            services.AddAuthentication();

            //CORS
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins(new[]
                    {
                        "http://localhost:4200",
                        "http://localhost:50000"
                    })
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });



            /// AutoMapper <-> Mapeos de Entidades
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            ///Base de datos SQL SERVER
            string strCnn = configuration.GetConnectionString("Conexion").ToString();
            services.AddDbContextPool<RestauranntDBContext>(
                options => options.UseLazyLoadingProxies().UseSqlServer(strCnn)
                );

            //Inyectando los servicios de Repository
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClientesRepository, ClienteRepository>();

            services.AddControllers().AddNewtonsoftJson(options =>
              options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            //app.UseAuthentication();
            //app.UseAuthorization();

            //app.UseCors("Todos");
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
