using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using FormHelper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OdalysProject.Web.Data;
using OdalysProject.Web.Interfaces;
using OdalysProject.Web.Interfaces.Base;
using OdalysProject.Web.Models;
using OdalysProject.Web.Repositories;
using OdalysProject.Web.Repositories.Base;
using OdalysProject.Web.Validator;

namespace OdalysProject.Web
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
            services.AddMvc(setup =>
            {
                //...mvc setup...
            }).AddFluentValidation();


            //DbContext

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //Repositories

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IRentBookRepository, RentBookRepository>();

            //FluentValidation

            services.AddTransient<IValidator<Book>, BookValidator>();
            services.AddTransient<IValidator<Author>, AuthorValidator>();
            services.AddTransient<IValidator<Category>, CategoryValidator>();
            services.AddTransient<IValidator<Publisher>, PublisherValidator>();
            services.AddTransient<IValidator<Student>, StudentValidator>();

            services.AddControllersWithViews();

            services.AddRazorPages();


            services.AddSwaggerDocument();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();


            });
        }



    }
}

