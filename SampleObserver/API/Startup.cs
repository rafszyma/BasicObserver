using System.IO;
using System.Text.Json.Serialization;
using API.Client;
using API.Services;
using Contracts;
using Contracts.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Shared.Bootstrap;
using Shared.Persistence;

namespace API
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
            services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            var configProvider = new BasicConfiguration();
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables().Build().Bind(configProvider);

            services
                .AddMongo(configProvider)
                .AddConfigProvider(configProvider)
                .AddScoped<ITimeSeriesChannelProvider, TimeSeriesChannelProvider>()
                .AddScoped<ITimeSeriesCommandRepository, MongoTimeSeriesCommandRepository>()
                .AddScoped<ITimeSeriesService, TimeSeriesService>()
                .AddScoped<ITenantContext, WebTenantContext>()
                .AddScoped<ITenantHttpHandler, TenantHttpHandler>()
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                    c.DescribeAllParametersInCamelCase();
                    
                })
                .AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
                });
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}