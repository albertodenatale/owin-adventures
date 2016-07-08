using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OwinAdventures.Middlewares
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class Logger
    {
        private AppFunc _next;

        public Logger(AppFunc next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            await _next.Invoke(environment);

            Log(environment);
        }

        private static void Log(IDictionary<string, object> environment)
        {
            Console.WriteLine("hello");
        }
    }
}
