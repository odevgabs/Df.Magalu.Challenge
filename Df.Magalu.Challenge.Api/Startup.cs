using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Df.Magalu.Challenge.Domain.Entity;
using Df.Magalu.Challenge.Domain.Dto;
using AutoMapper;
using Df.Magalu.Challenge.Service;
using Df.Magalu.Challenge.Service.Interfaces;
using Df.Magalu.Challenge.Domain.Interfaces.Factories;
using Df.Magalu.Challenge.Domain.Factories;
using Df.Magalu.Challenge.Domain.Interfaces.Acl;
using Df.Magalu.Challenge.Acl;
using Df.Magalu.Challenge.Domain.Interfaces.Repositories;
using Df.Magalu.Challenge.Data;
using Df.Magalu.Challenge.Data.Context;
using Df.Magalu.Challenge.Data.Repositories;

namespace Df.Magalu.Challenge.Api
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
            services.AddOptions();
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Magalu Challege", Version = "v1" });
            });

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductLabsDto,Product>();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);



            services.AddTransient<IClientFactory, ClientFactory>();

            services.AddTransient<IProductLabsAcl, ProductLabsAcl>();

            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IClientRepository, ClientRepository>();

            services.AddTransient<IClientService, ClientService>();



        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Magalu Challege");
            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
