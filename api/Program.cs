using api.Contexts;
using api.Datastores;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDataStore, MySQLDataStore>();

//string _connectionString = $"server={builder.Configuration["MYSQL_SERVER_NAME"]}; database={builder.Configuration["MYSQL_DATABASE"]}; user={builder.Configuration["MYSQL_USER"]}; password={builder.Configuration["MYSQL_PASSWORD"]}";
string _connectionString = $"server=localhost; database=cookus; user=root; password=root";
builder.Services.AddDbContext<CookUsContext>(options => options.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
