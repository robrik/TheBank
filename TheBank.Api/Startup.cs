using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TheBank.Data.LoanApplication;
using TheBank.Logic.LoanApplication;

namespace TheBank.Api
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
            // Needed By swagger to generate api info
            services.AddMvcCore().AddApiExplorer();
            // Swagger
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "TheBank Api" });
            });

            // Database
            services.AddDbContext<LoanApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ApplicationDatabase")));

            // Controllers
            services.AddControllers();

            // Other dependencies
            services.AddScoped<ILoanApplicationLogic, LoanApplicationLogic>();
            services.AddScoped<ILoanApplicationContextFacade, LoanApplicationContextFacade>();
        }

       
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TheBank Api");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                
            });
        }
    }
}
