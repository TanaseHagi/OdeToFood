using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OdeToFood.Data;
using OdeToFood.Services;

namespace OdeToFood
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
            services.AddDbContext<OdeToFoodDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("OdeToFood")));
            services.AddScoped<IRestaurantData, SqlRestaurantData>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                                IHostingEnvironment env, 
                                IGreeter greeter, 
                                IConfiguration config, 
                                ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseFileServer();
            // app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseNodeModules(env.ContentRootPath);

            app.UseMvc(ConfigureRoutes);
            
            //app.Use(next =>
            //{
            //    return async context =>
            //    {
            //        logger.LogInformation("Request incomming...");
            //        if (context.Request.Path.StartsWithSegments("/mym"))
            //        {
            //            await context.Response.WriteAsync("Hit");
            //            logger.LogInformation("Request handled...");
            //        }
            //        else
            //        {
            //            await next(context);
            //            logger.LogInformation("Response outgoing...");
            //        }
            //    };
            //});

            //app.UseWelcomePage(new WelcomePageOptions
            //{
            //    Path = "/wp",
            //});

            //app.Run(async (context) =>
            //{
            //    context.Response.ContentType = "text/html";
            //    await context.Response.WriteAsync("Not Found!");
            //    // await context.Response.WriteAsync($"Hello World! {greeter.getMessageOfTheDay()} {config["Greeting"]}");
            //});
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            // /Home/Index
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
