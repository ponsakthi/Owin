using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatanaIntro
{
    public class PrintEnvironmentComponent
    {
        private Func<IDictionary<string, object>, Task> _next;

        public PrintEnvironmentComponent(Func<IDictionary<string, object>, Task> next)
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
}