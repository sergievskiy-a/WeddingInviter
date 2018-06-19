using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FamilySite.Web.Api.Services;
using FamilySite.Data;
using FamilySite.Data.Entites;
using FamilySite.Data.Contracts.Repositories;
using FamilySite.Data.Repositories;
using FamilySite.Services;
using FamilySite.Services.Contracts;
using FamilySite.IoC.AutoMapperProfiles;
using AutoMapper;
using System.Reflection;

using FamilySite.Web.Api.Config;

namespace FamilySite.Web.Api
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
            services.AddAutoMapper(typeof(InviteProfile).GetTypeInfo().Assembly);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IWeddingService, WeddingService>();
            services.AddTransient<IInviteService, InviteService>();
            services.AddTransient<IGuestService, GuestService>();

            services.AddCors();
            services.AddMvc();

            services.Configure<Settings>(options =>
                {
                    options.ConnectionString
                        = Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
                    options.ApiDomain
                        = Configuration.GetSection("Domains:ApiDomain").Value;
                    options.ClientDomain
                        = Configuration.GetSection("Domains:ClientDomain").Value;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
