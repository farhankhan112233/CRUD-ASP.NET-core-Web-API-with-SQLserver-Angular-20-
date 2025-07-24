using Microsoft.EntityFrameworkCore;
using Representational_State_Transfer.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var angularOrigin = "http://localhost:4200";

// Add CORS policy for Angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins(angularOrigin)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAngularApp");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
