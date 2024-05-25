using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TemplateWebApi.Data;
using TemplateWebApi.Data.Entities;

var builder = WebApplication.CreateBuilder(args);
var configuring = builder.Configuration;
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme)
                .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddIdentityCore<User>()
        .AddEntityFrameworkStores<TemplateDbContext>()
        .AddApiEndpoints();

builder.Services.AddDbContext<TemplateDbContext>(options =>
                options.UseNpgsql(configuring.GetConnectionString("WebApiDatabase")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapIdentityApi<User>();

app.Run();

