using GamesPlatform.Domain.Repositories;
using GamesPlatform.Infrastructure.AutoMappers;
using GamesPlatform.Infrastructure.Commands;
using GamesPlatform.Infrastructure.EntityFramework;
using GamesPlatform.Infrastructure.Extensions;
using GamesPlatform.Infrastructure.Models;
using GamesPlatform.Infrastructure.Repositiories;
using GamesPlatform.Infrastructure.Services;
using GamesPlatform.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

public static class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.ConfigureOptions<JwtOptionsSetup>();

        builder.Services.AddAuthentication()
                        .AddJwtBearer(cfg =>
                        {
                            cfg.TokenValidationParameters = new TokenValidationParameters
                            {
                                //ValidIssuer = "https://localhost:7101",
                                //ValidateAudience = false,
                                //IssuerSigningKey = 
                            };
                        });

        builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddSingleton<IEncrypter, Encrypter>();

        builder.Services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        builder.Services.AddCommandHandlers();

        builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("UserContext")));

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