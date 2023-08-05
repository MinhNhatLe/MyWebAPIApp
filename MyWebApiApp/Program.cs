using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyWebApiApp.Data;
using MyWebApiApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("MyDB");
builder.Services.AddDbContext<MyDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<ILoaiRepository, LoaiRepository>();
//builder.Services.AddScoped<ILoaiRepository, LoaiRepositoryInMemory>();

builder.Services.AddScoped<IHangHoaResposity, HangHoaRepository>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
