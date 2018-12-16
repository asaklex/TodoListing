using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TodoListing.Auth;
using TodoListing.Auth.TokenAuth;
using TodoListing.DAL;
using TodoListing.Services.DataServices;

namespace TodoListing.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = TokenAuthOptions.DefaultScheme;
                options.DefaultChallengeScheme = TokenAuthOptions.DefaultScheme;
            })
            .AddTokenAuth(options => {

                var apikeys = Configuration.GetSection("ApiKeys")
                  .AsEnumerable()
                  .Where(x => !string.IsNullOrEmpty(x.Value))
                  .Select(x => x.Value)
                  .ToArray();

                options.AuthKeys = apikeys;
            });

            //add Entity Framework 
            var connectionString = Configuration.GetConnectionString("TodoListingDbContext");
            services.AddDbContext<TodoListingDbContext>(options => options.UseSqlServer(connectionString));

            services.AddSingleton<ITodoDataServices, TodoDataServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
