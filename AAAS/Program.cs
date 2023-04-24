using AAAS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

//SQLite
builder.Services.AddDbContext<AAAS_DbContext>(options =>
{
    //todo path to in project file
    var path = Path.Combine(Environment.CurrentDirectory, "Data", "AAAS.db");
    var connectionString = @"Data Source=" + path;
    options.UseSqlite(connectionString);
});



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());


//Apply migration at runtime
//Applies initial Seeding if not already done
IApplicationBuilder applicationBuilder = app;
using (IServiceScope scope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var dbContext = scope.ServiceProvider.GetService<AAAS_DbContext>();
    dbContext.Database.EnsureCreated();
    Seeder seeder = new Seeder();
    seeder.Seed(dbContext);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Use Swagger in Heroku
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllers();

app.Run();
