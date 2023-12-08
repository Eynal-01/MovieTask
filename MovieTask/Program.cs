using Microsoft.EntityFrameworkCore;
using MovieTask.Controllers;
using MovieTask.Data;
using MovieTask.Repositories.Abstract;
using MovieTask.Repositories.Concrete;
using MovieTask.Services;
using MovieTask.Services.Abstract;
using MovieTask.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHostedService<BackgroundWorkerService>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IGetMovieService, GetMovieService>();
builder.Services.AddScoped<MovieController>();

var connection = builder.Configuration.GetConnectionString("myconn");
builder.Services.AddDbContext<MovieDbContext>(opt =>
{
    opt.UseSqlServer(connection);
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
