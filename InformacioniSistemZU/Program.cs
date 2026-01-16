using AutoMapper;
using InformacioniSistemZU.BusinessModell.RepositoriesBM;
using InformacioniSistemZU.DataModel.Repositories;
using InformacioniSistemZU.MainDbContext;
using InformacioniSistemZU.Mapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConn")));

builder.Services.AddScoped<ILekarRepository, LekarRepository>();
builder.Services.AddScoped<ILekarRepositoryBM, LekarRepositoryBM>();

builder.Services.AddAutoMapper(ops => ops.AddProfile<DataModel2BusinessModel>());


builder.Services.AddControllers();
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
