using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using SurveyQuestions.Models;
namespace SurveyQuestions
{
    public class Startup
    {
        IConfigurationRoot Configuration;
        public Startup(IWebHostEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json").Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IQuestionRepository, EFQuestionRepository>();
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }
 public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory
loggerFactory)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes => {
                routes.MapRoute(
                name: "default",
                template: "{controller=Question}/{action=List}/{id?}");
            });
        }
    }
}
