using System.Text;
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
using BorrowMyGameDotNet.Data.Contexts;
using System;
using BorrowMyGameDotNet.Data.MongoDB;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using BorrowMyGameDotNet.Modules.Auth.Domain.Entities;
using BorrowMyGameDotNet.Constants;

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
            ConfigureMongoDB(services);

            services.AddControllers();

            ConfigureSwagger(services);
            ConfigureEntityFramework(services);
            ConfigureAuthentication(services);
            InjectDependencies(services);
        }

        private void ConfigureMongoDB(IServiceCollection services)
        {
            services.AddTransient<IMongoClient>(serviceProvider =>
            {
                var mongoDBHost = Environment.GetEnvironmentVariable(EnvironmentVariables.MongoDBHost);
                var mongoDBUsername = Environment.GetEnvironmentVariable(EnvironmentVariables.MongoDBUsername);
                var mongoDBPassword = Environment.GetEnvironmentVariable(EnvironmentVariables.MongoDBPassword);
                var connectionString = $"mongodb://{mongoDBUsername}:{mongoDBPassword}@{mongoDBHost}:27017/?authSource=admin";
                return new MongoClient(connectionString);
            });


            services.AddTransient<IMongoDatabase>(serviceProvider =>
            {
                var mongoDBDatabase = Environment.GetEnvironmentVariable(EnvironmentVariables.MongoDBDatabase);
                var client = serviceProvider.GetService<IMongoClient>();
                return client.GetDatabase(mongoDBDatabase);
            });

            services.AddTransient<MongoDBDatabase>();
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
                options =>
                {
                    var mysqlHost = Environment.GetEnvironmentVariable(EnvironmentVariables.MySqlHost);
                    var mysqlDatabase = Environment.GetEnvironmentVariable(EnvironmentVariables.MySqlDatabase);
                    var mysqlUsername = Environment.GetEnvironmentVariable(EnvironmentVariables.MySqlUsername);
                    var mysqlPassword = Environment.GetEnvironmentVariable(EnvironmentVariables.MySqlPassword);

                    var connectionString = $"server={mysqlHost};port=3306;database={mysqlDatabase};uid={mysqlUsername};password={mysqlPassword}";
                    options.UseMySQL(connectionString);
                }
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
