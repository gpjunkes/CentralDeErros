using CentralDeErros.Dados;
using CentralDeErros.Dados.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CentralDeErros.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddScoped<IEventoRepositorio, EventoRepositorio>();

            services.AddDbContext<Contexto>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyConnection")));

            services.AddSwaggerGen(s => s.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Central de erros - Guilheme Junkes", Version = "v1" }));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Central de erros - Guilhemrme Junkes");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
