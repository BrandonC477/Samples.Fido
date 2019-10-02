﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Passwordless
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddFido(options =>
                {
                    options.Licensee = "";
                    options.LicenseKey = "";
                })
                .AddInMemoryKeyStore();

            services.AddAuthentication("cookie")
                .AddCookie("cookie", options => { options.LoginPath = "/Home/Login"; });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
