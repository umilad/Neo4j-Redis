using Microsoft.Extensions.DependencyInjection;
using Neo4j.Driver;
using Neo4j.Berries.OGM;
using Neo4j.Berries.OGM.Contexts;
using KrvNijeVoda.Back.Configurations;

var builder = WebApplication.CreateBuilder(args);

var neo4jUri = "neo4j+s://84307b33.databases.neo4j.io";
var neo4jUser = "neo4j";
var neo4jPassword = "AEYgjhymGHlfJt2zx5MRhtkd6HZaSWCIQGgMITq0u6E";

// Add services to the container.

// Register Neo4j driver as a singleton
var driver = GraphDatabase.Driver(neo4jUri, AuthTokens.Basic(neo4jUser, neo4jPassword));
builder.Services.AddSingleton<IDriver>(driver);



// Register Neo4jService
builder.Services.AddSingleton<Neo4jService>();

// // Register Neo4jOptions with the necessary configurations
// builder.Services.AddSingleton<Neo4jOptions>(provider =>
// {
//     var driver = provider.GetRequiredService<IDriver>();
//     return new Neo4jOptions(driver); // Adjust constructor if necessary
// });

// Register the configuration for Neo4j from appsettings.json
builder.Services.Configure<Neo4jOptions>(builder.Configuration.GetSection("Neo4j"));

// builder.Services.AddSingleton<Neo4jService>(new Neo4jService("neo4j+s://84307b33.databases.neo4j.io",
//  "neo4j",
//  "AEYgjhymGHlfJt2zx5MRhtkd6HZaSWCIQGgMITq0u6E"));
//builder.Services.AddSingleton<LicnostConfiguration>();

//builder.Services.AddNeo4j<MyGraphContext>(builder.Configuration, typeof(Program).Assembly);
builder.Services.AddNeo4j<MyGraphContext>(builder.Configuration, options =>
{
    options
        .ConfigureFromAssemblies(typeof(Program).Assembly);
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(Program).Assembly));
//builder.Services.AddNeo4j<ApplicationGraphContext>(builder.Configuration, typeof(Program).Assembly);

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
