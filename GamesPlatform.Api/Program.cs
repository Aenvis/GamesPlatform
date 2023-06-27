using GamesPlatform.Domain.Repositories;
using GamesPlatform.Infrastructure.AutoMappers;
using GamesPlatform.Infrastructure.Commands;
using GamesPlatform.Infrastructure.EntityFramework;
using GamesPlatform.Infrastructure.Extensions;
using GamesPlatform.Infrastructure.Models;
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

        builder.Services.AddAuthorization(x => x.AddPolicy("user", p => p.RequireRole("user")));
        builder.Services.AddAuthorization(x => x.AddPolicy("admin", p => p.RequireRole("admin")));

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

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddSingleton<IEncrypter, Encrypter>();
        builder.Services.AddSingleton<IJwtHandler, JwtHandler>(services => new JwtHandler(services.GetRequiredService<JwtSettings>()));

        builder.Services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        builder.Services.AddCommandHandlers();

        builder.Services.AddMemoryCache();

        builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("UserDbContext")));
        builder.Services.AddDbContext<GameDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GameDbContext")));

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            SeedUserData.Initialize(serviceProvider);
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