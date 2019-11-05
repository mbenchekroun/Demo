using System;
using Dapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MySql.Data.MySqlClient;
using System.Data;
using Demo.Services;

namespace Demo
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
            var env = Environment.GetEnvironmentVariables();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo", Version = "v1" });
            });

            services
                .AddTransient<IProductService, ProductService>()
                .AddTransient<IDbConnection>(p =>
                {
                    var connection = new MySqlConnection($@"server={env["MYSQL_IP"]};database={env["MYSQL_DATABASE"]};uid={env["MYSQL_USER"]};pwd={env["MYSQL_ROOT_PASSWORD"]};");
                    SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
                    connection.Open();
                    return connection;
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo API V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseMvc();
        }
    }
}
