using Neo4j.Berries.OGM;
using Neo4j.Berries.OGM.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<Neo4jService>(new Neo4jService("neo4j+s://84307b33.databases.neo4j.io",
 "neo4j",
 "AEYgjhymGHlfJt2zx5MRhtkd6HZaSWCIQGgMITq0u6E"));
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
