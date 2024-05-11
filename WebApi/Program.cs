using DataAccess.EFCore;
using DataAccess.EFCore.Repositories;
using DataAccess.EFCore.UnitOfWork;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => {
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("WebApi"));
});

#region Repositories
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IDeveloperRepository, DeveloperRepository>();
builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
#endregion

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        b => b.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod());

});

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

//var connectionString = builder.Configuration.GetConnectionString("AppDb");
//builder.Services.AddDbContext<ApplicationContext>(x => {
//    x.UseSqlServer(connectionString);
//});

//services.AddDbContext<ApplicationContext>(options =>
//options.UseSqlServer(
//    Configuration.GetConnectionString("DefaultConnection"),
//    b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

