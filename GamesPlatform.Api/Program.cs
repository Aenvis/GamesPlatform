using GamesPlatform.Domain.Repositories;
using GamesPlatform.Infrastructure.AutoMappers;
using GamesPlatform.Infrastructure.Commands;
using GamesPlatform.Infrastructure.Consts;
using GamesPlatform.Infrastructure.EntityFramework;
using GamesPlatform.Infrastructure.Extensions;
using GamesPlatform.Infrastructure.Models;
using GamesPlatform.Infrastructure.Queries;
using GamesPlatform.Infrastructure.Repositiories;
using GamesPlatform.Infrastructure.Services;
using GamesPlatform.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

public static class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // JwtSettings is registered this way because of IoC issues with JwtHandler and
        // AddCommandHandlers extension method (JwtHandler would count as a CommandHandler, not intended)
        var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();
        builder.Services.AddSingleton(jwtSettings!);

        // Authorization and authentication
        builder.Services.AddAuthorization(x => x.AddPolicy(Roles.User, p => p.RequireRole(Roles.User)));
        builder.Services.AddAuthorization(x => x.AddPolicy(Roles.Admin, p => p.RequireRole(Roles.Admin)));
        builder.Services.AddAuthentication()
                        .AddJwtBearer(cfg =>
                        {
                            var key = builder.Configuration.GetValue<string>("Jwt:Key");
                            cfg.RequireHttpsMetadata = false;
                            cfg.SaveToken = true;

                            cfg.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidIssuer = "https://localhost:7101",
                                ValidateAudience = false,
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                            };
                        });

        builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

        // Services
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IGameRepository, GameRepository>();
        builder.Services.AddScoped<IUserGameNodeRepository, UserGameNodeRepository>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IGameService, GameService>();
        builder.Services.AddScoped<IUserLibraryService, UserLibraryService>();
        builder.Services.AddSingleton<IEncrypter, Encrypter>();
        builder.Services.AddSingleton<IJwtHandler, JwtHandler>(services => new JwtHandler(services.GetRequiredService<JwtSettings>()));

        // CQRS
        builder.Services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        builder.Services.AddScoped<IQueryDispatcher, QueryDispatcher>();
        builder.Services.AddCommandHandlers();
        builder.Services.AddQueryHandlers();

        builder.Services.AddMemoryCache();

        // Database
        builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("UserDbContext")));
        builder.Services.AddDbContext<GameDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GameDbContext")));
        builder.Services.AddDbContext<UserGameNodeDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("USerGameNodeDbContext")));

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            SeedUserData.InitializeUserDbContext(serviceProvider);
            SeedUserData.InitializeGameDbContext(serviceProvider);
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}