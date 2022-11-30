using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebV1;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DatabaseOptionModel>(builder.Configuration.GetSection("SqlDatabase"));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();


app.MapGet("/", ([FromServices]IOptions<DatabaseOptionModel> options) => 
{
    return $"DbName: {options.Value.Name}, UserName: {options.Value.UserName}";
}).WithDisplayName("Get");

app.Run();