﻿using DigraphyApi.Data;
using DigraphyApi.Interfaces;
using DigraphyApi.Mapper;
using DigraphyApi.Repository;
using DigraphyApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var secretConnectionString = builder.Configuration["ConnectionStrings:DigraphyDatabase"];

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddDbContextPool<AppDbContext>(opt =>
{
    if (secretConnectionString != null)
        opt.UseNpgsql(builder.Configuration.GetConnectionString(secretConnectionString));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        // Update the SwaggerUI configuration to specify the base URL
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "DigraphyApi");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();