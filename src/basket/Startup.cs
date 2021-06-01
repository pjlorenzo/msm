using AutoMapper;
using basket.Entities;
using basket.Models;
using basket.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basket
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
            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "basket", Version = "v1" });
            });

            services.AddDbContext<BasketDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddTransient<IBasketRepository, BasketRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            var butterConditionProduct = new Product { Id = 1, Price = 0.80M, Quantity = 2, Description = "Butter" };
            var breadTargetDiscountProduct = new Product { Id = 3, Price = 1M, Quantity = 2, Description = "Bread" };
            services.AddTransient<IDiscount>(p => new PercentageDiscount(breadTargetDiscountProduct,0.5M,butterConditionProduct));
            var milkProductCondition = new Product { Id = 2, Price = 1.15M, Quantity = 4, Description = "Milk" };
            services.AddTransient<IDiscount>(p=> new QuantityProductDiscount(milkProductCondition, 1.15M));
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMapper mapper)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "basket v1"));
            }
            
            mapper.ConfigurationProvider.AssertConfigurationIsValid();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
