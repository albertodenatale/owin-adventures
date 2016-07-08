using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OwinAdventures.Middlewares
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class ImageResizer
    {
        AppFunc _next;

        public ImageResizer(AppFunc next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string,object> environment)
        {
            await _next.Invoke(environment);
        }
    }
}
