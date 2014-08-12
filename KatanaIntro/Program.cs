using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            appBuilder.UseWelcomePage();
            //appBuilder.Run((ctx) =>
            //{
            //    return ctx.Response.WriteAsync("Hello World!!!");
            //});
        }
    }
}
