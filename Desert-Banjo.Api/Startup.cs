using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Desert.Banjo.Data;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Options;


namespace Desert.Banjo.Api
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
            var builder = WebApplication.CreateBuilder();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
           builder.Services.AddDbContext<StoreContext>(options =>
                options.UseSqlite("Data Source=../Registrar.sqlite",
                    b => b.MigrationsAssembly("Desert.Banjo.Api")));
                builder.Services.AddCors(Options => {
                    Options.AddDefaultPolicy(builder =>{
                        builder.WithOrigins("http://localhose:3000")
                        .AllowAnyHeader()
                        .AllowAnyHeader();
                    });
                });
                builder.Services.AddEndpointsApiExplorer();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
"Desert.Banjo.Api v1"));
            }
            app.UseCors();
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
