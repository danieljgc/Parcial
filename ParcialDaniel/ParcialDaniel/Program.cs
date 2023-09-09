using data;
using data.repositorio;
using ParcialDaniel.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connection = new mysqlConfig(builder.Configuration.GetConnectionString("mysqlConnection"));
builder.Services.AddSingleton(connection);
builder.Services.AddScoped<iClienteRepository, clienteRepository>();
builder.Services.AddScoped<iEmpleadoRepository, empleadoRepository>();
//builder.Services.AddScoped<>();
//builder.Services.AddScoped<>();
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
