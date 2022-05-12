using MediatR;
using Microsoft.AspNetCore.OData;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using WebApi.Sample.Db;
using WebApi.Sample.Models.V1;

static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new();
    builder.EntitySet<TodoModel>("Todos");
    return builder.GetEdmModel();
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddOData(opt => opt.AddRouteComponents("v1", GetEdmModel()).Filter().Select().Expand());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "ODataTutorial", Version = "v1" });
});
builder.Services.AddApiVersioning();
builder.Services.AddMediatR(typeof(Program).Assembly);

//var connectionString = "Data Source=InMemorySample;Mode=Memory;Cache=Shared";
var connectionString = "DataSource=:memory:";
var keepAliveConnection = new SqliteConnection(connectionString);
//keepAliveConnection.Open();

builder.Services.AddPooledDbContextFactory<SampleDbContext>(opt =>
{
    //opt.UseInMemoryDatabase("test");
    opt.UseSqlite(keepAliveConnection);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OData Api Sample v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
