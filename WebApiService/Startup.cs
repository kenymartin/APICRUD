using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApiService.CustomerServices;


namespace WebApiService
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
           
            try
            {
                services.AddDbContext<CustomerContext>(
                    opt =>
                        opt.UseInMemoryDatabase("Customer"));
                services.AddControllers();
                services.AddMvc().AddControllersAsServices();
                services.AddScoped<ICustomerService, CustomerService>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            

            //switch to Json file
            /*
            services.AddControllers();
            services.AddDbContextPool<CustomerContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("CustomerEntities")));
            services.AddScoped<ICustomerService, CustomerService>();
            */

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
