using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CiscoDevNet
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {

            //app.Use(async (c, v) => { await v(); });
            app.UseCors(bu => bu.AllowAnyOrigin());
            app.UseWebSockets();

            //app.Use(async (http, next) =>
            //{
            //    if (http.WebSockets.IsWebSocketRequest)
            //    {
            //        var webSocket = await http.WebSockets.AcceptWebSocketAsync();
            //        if (webSocket != null && webSocket.State == WebSocketState.Open)
            //        {

            //            // TODO: Handle the socket here.
            //        }
            //    }
            //    else
            //    {
            //        // Nothing to do here, pass downstream.  
            //        await next();
            //    }
            //});
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "def",
                    template: "{controller=Home}/{action=Index}"
                    );
            });


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
