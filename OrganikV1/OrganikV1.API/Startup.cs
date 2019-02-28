using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OrganikV1.Business.Abstract;
using OrganikV1.Business.Concrete;
using OrganikV1.Dal;
using OrganikV1.Dal.Abstract;
using OrganikV1.Dal.Concrete;
using OrganikV1.Entities.Entity;

namespace OrganikV1.API
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
            services.AddIdentity<CustomUser, CustomUserRole>(config =>
            {
                config.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultProvider;

            }).AddEntityFrameworkStores<CustomIdentityDbContext>().AddDefaultTokenProviders();

            services.AddDbContext<CustomIdentityDbContext>();
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
