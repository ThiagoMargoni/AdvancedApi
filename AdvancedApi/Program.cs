using AdvancedApi.Context;
using AdvancedApi.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using RoomsFullStack.Configurations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", builder =>
    {
         builder.AllowAnyOrigin()
         .AllowAnyHeader()
         .AllowAnyMethod();
    });
});

var con = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(con, ServerVersion.AutoDetect(con)));

builder.Services.AddScoped<IUnitOfWork, AppDbContext>();
builder.Services.AddClassesAsImplementedInterface(Assembly.GetEntryAssembly(), typeof(IService<>));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
