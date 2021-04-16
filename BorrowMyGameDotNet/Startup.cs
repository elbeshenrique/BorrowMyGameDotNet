using BorrowMyGameDotNet.Data;
using BorrowMyGameDotNet.Modules.Core.Application.Presenters;
using BorrowMyGameDotNet.Modules.Core.Application.Usecases;
using BorrowMyGameDotNet.Modules.Core.Domain.Presenters;
using BorrowMyGameDotNet.Modules.Core.Domain.Repositories;
using BorrowMyGameDotNet.Modules.Core.Domain.Usecases;
using BorrowMyGameDotNet.Modules.Core.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BorrowMyGameDotNet
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BorrowMyGameDotNet", Version = "v1" });
            });

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddTransient<IGamePresenter, GamePresenter>();
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<IGameUsecase, GameUsecase>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BorrowMyGameDotNet v1"));
            }

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
