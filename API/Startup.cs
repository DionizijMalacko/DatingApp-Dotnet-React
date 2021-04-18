using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
        //2. quick fix Initialize config from a parameter, dodaj _ ispred config
        private readonly IConfiguration _config;

        //configuration postaje config
        public Startup(IConfiguration config)
        {
            _config = config;
            //3. obrisi i ovu liniju
            //Configuration = configuration;
        }

        //1. obrisi ovu liniju
        //public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //nije vazan redosled ovde
            //Mora DataContext koji smo mi kreirali, ne moze DbContext direktno posto cemo imati problem
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(_config.GetConnectionString("DefaultConnection")); //ovako pristupamo bazi, u appsettings.development.json smo naveli DefaultConnection
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //da li smo u developmnet modu
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            //ako smo na http on nas redirektuje na https
            app.UseHttpsRedirection();

            //koristi rutiranje
            app.UseRouting();


            app.UseAuthorization();

            //proveruje sve endpointe i dodaje ih
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
