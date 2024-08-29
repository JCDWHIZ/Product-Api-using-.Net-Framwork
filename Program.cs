using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("ProductStore");

builder.Services.AddSqlite<ProductContext>(connString);


var app = builder.Build();

// map all endpoints
app.MapProductsEndpoints();

// migrate database on first run
app.MigrateDB();

app.Run();
