﻿namespace OwinAdventures
{
    using Microsoft.AspNetCore.Builder;

    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseMyOwinPipeline();
        }
    }
}
