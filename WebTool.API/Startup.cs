using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebTool.Core.ApplicationService;
using WebTool.Core.Interfaces;
using WebTool.Core.Services.Interfaces;
using WebTool.Infrastructure.EntityServices;
using WebTool.Infrastructure.Persistence;

namespace WebTool.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Services
            services.AddTransient<IUserService, UserService>();

            // Data Services
            services.AddTransient<IUserDataService, UserDataService>();

            // UnitOfWork
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // SQL server connection string
            var connection = @"Server=DESKTOP-F1B61FF\SQLEXPRESS;Database=WebTool;Trusted_Connection=True;ConnectRetryCount=0";

            // DbContext
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
