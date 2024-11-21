using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Xml.Linq;
using Microsoft.OpenApi.Models;
using TdoT_Backend.Services;


string swaggerVersion = "v1";
string swaggerTitle = "TdoTBE";
string corsKey = "_myCorsKey";

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddSwaggerGen()
    .AddCors(options => options.AddPolicy(
        corsKey,
        x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    ))
    .AddControllers();

builder.Services.AddScoped<DataService>();

var app = builder.Build();

app.MapControllers();

app.UseCors(corsKey);
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
