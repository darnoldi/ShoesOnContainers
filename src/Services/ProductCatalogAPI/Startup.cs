﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIStudio.Services.ProductCatalogAPI;
using APIStudio.Services.ProductCatalogAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ProductCatalogAPI
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
            services.Configure<CatalogSettings>(Configuration); // To make CatalogSettins injectable via IOptionsSnapshot

            //var hostname = Environment.GetEnvironmentVariable("SQLSERVER_HOST") ?? "product_catalog_MsSQL,1401";
            //var password = Environment.GetEnvironmentVariable("SA_PASSWORD") ?? "!IW2bac2821";
       
            //var connectionString = $"Server={hostname};Database=CatalogDb;User ID=sa;Password={password};";
           
            services.AddDbContext<CatalogDbContext>(options =>
                       options.UseSqlServer(Configuration["ConnectionString"]));

            services.AddMvc()
            .AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "APIStudio - Product Catalog HTTP API",
                    Version = "v1",
                    Description = "Product Catalog Microservice HTTP API, Data Driven CRUD microservice using MSSQL",
                    TermsOfService = "Terms Of Service : Internal ONLY - Company Confidential"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint($"/swagger/v1/swagger.json", "ProductCatalogAPI V1");
                });

            app.UseMvc();
        }
    }
}
