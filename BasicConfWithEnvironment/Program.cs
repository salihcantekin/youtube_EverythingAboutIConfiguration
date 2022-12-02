using Microsoft.Extensions.Configuration;

// bash
// environment=qa dotnet run

Environment.SetEnvironmentVariable("TestEnv", "Production");



IConfigurationRoot configuration = new ConfigurationBuilder()
    .AddJsonFile("appSettings.json")
    //.AddEnvironmentVariables()
    .AddEnvironmentVariables(prefix: "TechBuddyCongif_")
    .Build();

var dbName = configuration["DatabaseName"];
var userName = configuration["DefaultUserName"];
var env = configuration["TestEnv"];

Console.WriteLine($"DbName: {dbName}, UserName: {userName}, Env: {env}");

Console.ReadLine();
