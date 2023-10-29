using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.src.interfaces;
using WebApplication1.src.services;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Identity;
using WebApplication1.src.models;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbContextt>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(options=>{
    options.DefaultAuthenticateScheme = "Bearer";
    options.DefaultChallengeScheme = "Bearer";
    options.DefaultScheme = "Bearer";
});
builder.Services.AddScoped<ILogin, LoginService>();
builder.Services.AddScoped<IRegister, RegisterService>();
builder.Services.AddScoped<IPasswordHasher<Users>, PasswordHasher<Users>>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//cors
app.UseCors("AllowAll"); // Coloca UseCors antes de UseAuthorization

app.MapControllers();

app.Run();
