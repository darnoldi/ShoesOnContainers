﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arnoldi.Services.EntityRelationshipManagerAPI;
using Arnoldi.Services.EntityRelationshipManagerAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace EntityRelationshipManagerAPI
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

            var hostname = Environment.GetEnvironmentVariable("SQLSERVER_HOST") ?? "localhost,1402";
            var password = Environment.GetEnvironmentVariable("SA_PASSWORD") ?? "!IW2bac2821";
       
            var connectionString = $"Server={hostname};Database=EntityRelationshipDb;User ID=sa;Password={password};";
           
            services.AddDbContext<EntityRelationshipDbContext>(options =>
                       options.UseSqlServer(connectionString));

            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
