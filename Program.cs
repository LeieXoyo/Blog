using Microsoft.EntityFrameworkCore;
using Blog.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BlogContext>(opt =>
    opt.UseSqlite("Data Source=Blog.db;")
);
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();
