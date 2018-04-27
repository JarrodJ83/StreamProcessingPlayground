﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using UserRegistration.Persistance;
using UserRegistration.Persistance.Model;

namespace UserRegistration.WebApi
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
            services.AddMvc();
            services.AddDbContext<UsersDbContext>(options =>
            {
                  options.UseSqlite("Data Source=UserRegistration.db", 
                            o => o.MigrationsAssembly("UserRegistration.WebApi"));
            });
            services.AddTransient<IUserRegistrationService, UserRegistrationService>();
            services.AddSingleton<IStreamProducer<int, string>, KafkaStreamProducer>();
            services.AddSingleton<Producer<int, string>>(serviceProvider => new Producer<int, string>(new Dictionary<string, object> 
                        { 
                            { "bootstrap.servers", "localhost:9092" } 
                        }, new IntSerializer(), new StringSerializer(Encoding.UTF8))
            );
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
