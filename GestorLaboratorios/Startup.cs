using GestorLaboratorios.Models;
using GestorLaboratorios.Services;
using GestorLaboratorios.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Rotativa.AspNetCore;
using System;


namespace GestorLaboratorios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});
            services.AddDbContext<DBGESTORContext>(options => options.UseMySql(Configuration.GetConnectionString("LibraryCoon")));
            services.AddScoped<LoginRepositorio, LoginRepositorio>();
            services.AddScoped<ConfiguracionRepositorio, ConfiguracionRepositorio>();
            services.AddScoped<InicioRepositorio, InicioRepositorio>();
            services.AddScoped<PdfRepositorio, PdfRepositorio>();
            services.AddScoped<Encrypter>();
            services.AddScoped<VerifyUserAttribute>();


            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = ".aspnetcore.session";
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
            });


            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            RotativaConfiguration.Setup(env);

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Login}/{id?}");
            });
        }
    }
}
