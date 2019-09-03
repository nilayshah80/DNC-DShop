using System;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DShop.Common.Dispatchers;
using DShop.Common.Mongo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DShop.Common.Mvc;
using DShop.Services.Discounts.Domain;
using DShop.Common;
using DShop.Common.RabbitMq;
using DShop.Services.Discounts.Messages.Commands;
using DShop.Services.Discounts.Messages.Events;

namespace DShop.Services.Discounts
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IContainer Container { get; private set; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCustomMvc();
            services.AddInitializers(typeof(IMongoDbInitializer));

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly()).AsImplementedInterfaces(); //For Repository or for single repository can you below commented code
            //builder.RegisterType<DiscountsRepository>().As<IDiscountsRepository>();
            builder.Populate(services);
            builder.AddDispatchers();
            builder.AddMongo();
            builder.AddMongoRepository<Discount>("Discounts");
            builder.AddMongoRepository<Customer>("Customers");
            builder.AddRabbitMq();

            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IApplicationLifetime applicationLifetime, IStartupInitializer initializer)
        {
            if (env.IsDevelopment() || env.EnvironmentName == "local")
            {
                app.UseDeveloperExceptionPage();
            }

            initializer.InitializeAsync();

            app.UseMvc();
            app.UseRabbitMq()
                .SubscribeCommand<CreateDiscount>()
                 .SubscribeEvent<CustomerCreated>();

            //To Do: Why below code not working for discount service
            //applicationLifetime.ApplicationStarted.Register(() => Container.Dispose());
            
        }
    }
}
