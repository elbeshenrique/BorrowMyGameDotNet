using System.Text;
using BorrowMyGameDotNet.Data;
using BorrowMyGameDotNet.Modules.Auth.Application.Usecases;
using BorrowMyGameDotNet.Modules.Auth.Domain.Repositories;
using BorrowMyGameDotNet.Modules.Auth.Domain.Usecases;
using BorrowMyGameDotNet.Modules.Auth.Infrastructure;
using BorrowMyGameDotNet.Modules.Auth.Security;
using BorrowMyGameDotNet.Modules.Core.Application.Presenters;
using BorrowMyGameDotNet.Modules.Core.Application.Usecases;
using BorrowMyGameDotNet.Modules.Core.Domain.Presenters;
using BorrowMyGameDotNet.Modules.Core.Domain.Repositories;
using BorrowMyGameDotNet.Modules.Core.Domain.Usecases;
using BorrowMyGameDotNet.Modules.Core.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Threading.Tasks;

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

            ConfigureSwagger(services);
            ConfigureEntityFramework(services);
            ConfigureAuthentication(services);
            InjectDependencies(services);
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BorrowMyGameDotNet", Version = "v1" });
            });
        }

        private void ConfigureEntityFramework(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"))
            );
        }

        private void ConfigureAuthentication(IServiceCollection services)
        {
            var symmetricKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtSecurityInfo.SecurityKey));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = symmetricKey,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = false,
                    ValidIssuer = JwtSecurityInfo.Issuer,
                    ValidAudience = JwtSecurityInfo.Audience,
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = async (context) =>
                    {
                        await Task.Yield();
                    },
                    OnForbidden = async (context) =>
                    {
                        await Task.Yield();
                    },
                    OnMessageReceived = async (context) =>
                    {
                        await Task.Yield();
                    },
                    OnTokenValidated = async (context) =>
                    {
                        await Task.Yield();
                    },
                    OnChallenge = async (context) =>
                    {
                        await Task.Yield();
                    }
                };
            });
        }

        private void InjectDependencies(IServiceCollection services)
        {
            services.AddTransient<IGamePresenter, GamePresenter>();
            services.AddTransient<IGameRepository, GameEFRepository>();
            services.AddTransient<IGameUsecase, GameUsecase>();

            services.AddTransient<IUserRepository, UserMongoDBRepository>();
            services.AddTransient<IUserUsecase, UserUsecase>();
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

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
