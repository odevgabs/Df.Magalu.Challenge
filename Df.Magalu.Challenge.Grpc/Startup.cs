using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Df.Magalu.Challenge.Acl;
using Df.Magalu.Challenge.Data;
using Df.Magalu.Challenge.Data.Context;
using Df.Magalu.Challenge.Data.Repositories;
using Df.Magalu.Challenge.Domain.Dto;
using Df.Magalu.Challenge.Domain.Entity;
using Df.Magalu.Challenge.Domain.Factories;
using Df.Magalu.Challenge.Domain.Interfaces.Acl;
using Df.Magalu.Challenge.Domain.Interfaces.Factories;
using Df.Magalu.Challenge.Domain.Interfaces.Repositories;
using Df.Magalu.Challenge.Grpc.Protos;
using Df.Magalu.Challenge.Service;
using Df.Magalu.Challenge.Service.Interfaces;
using Df.Magalu.Challenge.Service.Requests.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Df.Magalu.Challenge.Grpc
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductLabsDto, Product>();
                cfg.CreateMap<CreateRequestGrpc, ClientCreateRequest>();
            });
            config.AssertConfigurationIsValid();
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
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<ClientGrpcService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }

    }
}
