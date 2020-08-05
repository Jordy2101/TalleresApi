using TALLER.BUSINESS.Base.Contract;
using TALLER.DATA.Contrat;
using TALLER.DATA.Contrat.Base;
using TALLER.ENTITY;
using TALLER.ENTITY.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TALLER.BUSINESS.Engines;
using TALLER.DATA.Repository;
using TALLER.BUSINESS.Contract;

namespace Talleres
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.2342343243
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration["sqlconnection:connectionString"];

            //y services.Configure<AppSettings>(appSettings);
            var migrationAssembly = typeof(Startup).GetType().Assembly.GetName().Name;
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            services.AddDbContext<TalleresContext>(options =>
            {
                options.UseSqlServer(connectionString);

            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Talleres Api", Version = "v1" });
            });
            // services.AddScoped<IEngineBase<Company>, CompanyEngine>();

            services.AddScoped<IEngineBase<AUTOMOVIL>, AUTOMOVILEngine>();
            services.AddScoped<IBaseRepository<AUTOMOVIL>, AUTOMOVILRepository>();
            services.AddScoped<IAUTOMOVILEngine, AUTOMOVILEngine>();

            var mapper = Infraestructure.Mapping.MapperedEntities.GetMapper();
            services.AddSingleton(mapper);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors("CorsPolicy");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
