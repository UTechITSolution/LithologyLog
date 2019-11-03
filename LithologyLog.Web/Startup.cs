using AutoMapper;
using LithologyLog.Constant;
using LithologyLog.Model;
using LithologyLog.Model.Context;
using LithologyLog.Repository;
using LithologyLog.Web.Helper;
using LithologyLog.Web.Lang;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace LithologyLog.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            #region Identity

            services.AddIdentity<UserApp, ApplicationRole>()
                .AddEntityFrameworkStores<LithologyLogContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireNonAlphanumeric = false;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.AccessDeniedPath = "/Account/AccessDenied";
                });
            #endregion

            #region Database  access config
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<DbContext>(sp => sp.GetRequiredService<LithologyLogContext>());

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            #endregion

            #region Language config
            services.AddSingleton<LocalizerService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<LangService>();

            services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });

            #endregion

            #region General
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingEntity());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IFileProvider>(
             new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

            services.AddMvc()
             .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
             .AddDataAnnotationsLocalization(options =>
             {
                 options.DataAnnotationLocalizerProvider = (type, factory) =>
                 {
                     var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
                     return factory.Create("SharedResource", assemblyName.Name);
                 };
             })
             .AddJsonOptions(options =>
               {
                   options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                   options.SerializerSettings.DateFormatString = "dd'/'MM'/'yyyy HH:mm:ss";
               })
             .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            #endregion
        }


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

            #region For Decimal
            var cultureInfo = new CultureInfo("en-GB");
            cultureInfo.NumberFormat.NumberGroupSeparator = ".";

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            #endregion

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();


            #region Router Language config

            var supportedCultures = new List<CultureInfo>
             {
                   new CultureInfo(LANGCONSTANT.Az),
                   new CultureInfo(LANGCONSTANT.En),
                   new CultureInfo(LANGCONSTANT.Ru)
             };

            var localizationOptions = new RequestLocalizationOptions
            {
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                DefaultRequestCulture = new RequestCulture(LANGCONSTANT.Az),
            };


            var requestProvider = new RouteDataRequestCultureProvider();
            localizationOptions.RequestCultureProviders.Insert(0, requestProvider);

            var ci = new CultureInfo(LANGCONSTANT.Az);

            app.UseRouter(routes =>
            {
                routes.MapMiddlewareRoute("{culture=" + LANGCONSTANT.Az + "}/{*mvcRoute}", subApp =>
                {
                    subApp.UseRequestLocalization(localizationOptions);


                    subApp.UseMvc(mvcRoutes =>
                    {
                        mvcRoutes.MapRoute(
                          name: "defaultLangIndex",
                          template: "{culture=" + LANGCONSTANT.Az + "}/{controller=Home}/{action=Index}/{id?}");

                        mvcRoutes.MapRoute(
                           name: "default",
                           template: "/{controller=Home}/{action=Index}/{id?}");


                    });
                });
            });

            #endregion
        }
    }
}
