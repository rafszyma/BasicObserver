using System.IO;
using Contracts.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SampleObserver.API.Client;
using SampleObserver.API.Services;
using Shared;
using Shared.Bootstrap;
using Shared.Repository;

namespace SampleObserver.API
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
            var configProvider = new BasicConfiguration();
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables().Build().Bind(configProvider);

            services
                .AddMongo(configProvider)
                .AddConfigProvider(configProvider)
                .AddScoped<ITimeSeriesRepository, MongoTimeSeriesRepository>()
                .AddScoped<ITimeSeriesChannelProvider, TimeSeriesChannelProvider>()
                .AddScoped<ITimeSeriesService, TimeSeriesService>()
                .AddScoped<ITenantContext, WebTenantContext>()
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}