using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;

namespace KatanaIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press a key to get started");
            Console.ReadKey();
            var uri = "http://localhost:8080";
            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("Started");
                Console.ReadKey();
            }
            Console.WriteLine("Stopped");
            Console.ReadLine();
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.Use(async (env, next) =>
            {
                Console.WriteLine("Requesting :" + env.Request.Path);

                await next();

                Console.WriteLine("Resonse :" + env.Response.StatusCode);

            });


            ConfigureWebApi(appBuilder);
            appBuilder.Use<HelloWorldComponent>();
        }

        private void ConfigureWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("DefaultApi", 
                "api/{controller}/{id}", 
                new { id = RouteParameter.Optional });

            app.UseWebApi(config);
        }
    }
}
