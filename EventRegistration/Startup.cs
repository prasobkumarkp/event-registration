using EventRegistration.Data;
using EventRegistration.Models;
using EventRegistration.Services;
using EventRegistration.Services.Mocks;
using EventRegistration.Services.Sql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventRegistration
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<EventRegistrationDbContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddTransient<IRepository<Registration>, RegistrationRepository>();
            //services.AddTransient<IRepository<Day>, DayRepository>();
            //services.AddTransient<IRepository<Gender>, GenderRepository>();

            // Mock Repository
            services.AddSingleton<IRepository<Registration>, MockRegistrationRepository>();
            services.AddSingleton<IRepository<Day>, MockDayRepository>();
            services.AddSingleton<IRepository<Gender>, MockGenderRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            //using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            //{
            //    var dbContext = serviceScope.ServiceProvider.GetRequiredService<EventRegistrationDbContext>();
            //    var isCreated = dbContext.Database.EnsureCreated();
            //}

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Event}/{action=Index}/{id?}");
            });

        }
    }
}
