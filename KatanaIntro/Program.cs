using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Owin;

namespace KatanaIntro
{
    using AppFunc = Func<IDictionary<string,object>,Task> ;
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
            appBuilder.Use<PrintEnvironmentComponent>();

            appBuilder.Use(async (env, next) =>
            {
                Console.WriteLine("Requesting :" + env.Request.Path);

                await next();

                Console.WriteLine("Resonse :" + env.Response.StatusCode);

            });
            appBuilder.Use<HelloWorldComponent>();
        }
    }

    public class PrintEnvironmentComponent
    {
        private AppFunc _next;

        public PrintEnvironmentComponent(AppFunc next)
        {
            _next = next;
        }
        public async Task Invoke(IDictionary<string, object> environment)
        {
            foreach (var keyValue in environment)
            {
                Console.WriteLine("Key : {0} - Value : {1}",keyValue.Key,keyValue.Value);
            }

            await _next(environment);
        }
    }


    public class HelloWorldComponent
    {
        private AppFunc _next;

        public HelloWorldComponent(AppFunc next)
        {
            _next = next;
        }
        public Task Invoke(IDictionary<string, object> environment)
        {
            var responseStream = environment["owin.ResponseBody"] as Stream;
            using (var writer = new StreamWriter(responseStream))
            {
                return writer.WriteAsync("Hello world from Component");
            }
        }
    }
}
