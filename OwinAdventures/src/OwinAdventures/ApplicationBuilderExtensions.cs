using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace OwinAdventures
{
    using Middlewares;
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public static class ApplicationBuilderExtensions
    {
        public static void UseMyOwinPipeline(this IApplicationBuilder app)
        {
            //app.UseOwin(x => { x(next => ProcessImage); x(next => Log); });
            app.UseOwin(x => { x(next => new ImageResizer(next).Invoke); x(next => new Logger(next).Invoke); } );
        }

        public static async Task ProcessImage(IDictionary<string, object> environment)
        {
            var responseStream = (Stream)environment["owin.ResponseBody"];
            await responseStream.WriteAsync(new byte[0], 0, 0);
        }

        private static async Task Log(IDictionary<string, object> environment)
        {
            var responseStream = (Stream)environment["owin.ResponseBody"];
            await responseStream.WriteAsync(new byte[0], 0, 0);
        }

    }
}
