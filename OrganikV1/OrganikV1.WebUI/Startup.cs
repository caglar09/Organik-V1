using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using OrganikV1.Business.Abstract;
using OrganikV1.Business.Concrete;
using OrganikV1.Dal;
using OrganikV1.Dal.Abstract;
using OrganikV1.Dal.Concrete;
using OrganikV1.Entities.Entity;
using System.IO;
using System.Reflection;

namespace OrganikV1.WebUI
{
    public class Startup
    {


        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            _env = env;
            Configuration = configuration;

            //var a = configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
        }
        private IHostingEnvironment _env;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<OrganikV1DbContext>();

            services.AddScoped<IProductsService, ProductManager>();
            services.AddScoped<IProductsDal, EfLists.EfProductsDal>();

            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentsDal, EfLists.EfCommentsDal>();

            services.AddScoped<IProductPhotoService, ProductPhotoManager>();
            services.AddScoped<IProductPhotoDal, EfLists.EfProductsPhotoDal>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfLists.EfCategoriesDal>();

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserDal, EfLists.EfUsersDal>();

            services.AddAuthentication();
            services.AddMemoryCache();
            //services.AddIdentity<User, UserRole>().AddEntityFrameworkStores<OrganikV1DbContext>();

            services.AddIdentity<CustomUser, CustomUserRole>(config =>
            {
                config.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultProvider;

            }).AddEntityFrameworkStores<CustomIdentityDbContext>().AddDefaultTokenProviders();

            services.AddDbContext<CustomIdentityDbContext>();

            services.AddSession();
            services.AddRouting();
            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseDefaultFiles();
         
            app.UseIdentity();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                   name: "account",
                   template: "{controller=Account}/{action=Login}/{id?}");

                routes.MapRoute(
                   name: "user",
                   template: "{controller=User}/{action=Index}/{id?}");
            });
        }
    }
}
