using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Core.Models;
using LibraryApp.Core.Services;
using LibraryApp.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LIbraryAPI
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
            //services.AddDbContext<AppDbContext>();

            // Use SQL Database if in Azure, otherwise, use SQLite
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
                services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("LibraryDbConnection")));
            else
                services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlite("Data Source=books.db"));

            // Automatically perform database migration
            services.BuildServiceProvider().GetService<AppDbContext>().Database.Migrate();

            //Automatically perfrom database migration
            services.BuildServiceProvider().GetService<AppDbContext>().Database.Migrate();
            //blog startup has these:
            //services.AddScoped<DbInitializer>();
            //services.AddHttpContextAccessor();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICatalogRepository, CatalogRepository>();
            services.AddScoped<ICatalogService, CatalogService>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<ISeriesRepository, SeriesRepository>();
            services.AddScoped<ISeriesService, SeriesService>();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env /*blog startup: DbInitializer dbInitializer*/)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            //app.UseStaticFiles();
            app.UseAuthentication();

            //blog startup has this:
            //dbInitializer.Initialize();
        }
    }
}
