using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace KatanaIntro
{
    public class HelloWorldComponent
    {
        private Func<IDictionary<string, object>, Task> _next;

        public HelloWorldComponent(Func<IDictionary<string, object>, Task> next)
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