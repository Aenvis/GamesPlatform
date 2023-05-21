using Autofac;
using Autofac.Extensions.DependencyInjection;
using GamesPlatform.Domain.Repositories;
using GamesPlatform.Infrastructure.IoC;
using GamesPlatform.Infrastructure.Repositiories;
using GamesPlatform.Infrastructure.Services; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
