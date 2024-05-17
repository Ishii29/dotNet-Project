using Microsoft.Azure.Cosmos;
using Project.Data;

var builder = WebApplication.CreateBuilder(args);
 
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddSingleton((provider) =>
{
    var endpointUri = configuration.GetSection("EndpointUri").Value;
    var primaryKey = configuration.GetSection("PrimaryKey").Value; 
    var databaseName = configuration.GetSection("DatabaseName").Value; 

    var cosmosClientOptions = new CosmosClientOptions
    {
        ApplicationName = databaseName
    };

    var loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddConsole();
    });
    // Add services to the container.

    var cosmosClient = new CosmosClient(endpointUri, primaryKey, cosmosClientOptions);
    //builder.Services.AddControllers();
    //// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    //builder.Services.AddEndpointsApiExplorer();
    //builder.Services.AddSwaggerGen();

    cosmosClient.ClientOptions.ConnectionMode = ConnectionMode.Direct;

    return cosmosClient;
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProgramRepository, ProgramRepository>();


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
