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
    .AddSwaggerGen(x => x.SwaggerDoc(
        swaggerVersion,
        new OpenApiInfo { Title = swaggerTitle, Version = swaggerVersion }
    ))
    .AddCors(options => options.AddPolicy(
        corsKey,
        x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    ))
    .AddControllers();

builder.Services.AddScoped<DataService>();

var app = builder.Build();

app.UseCors(corsKey);

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(x => x.SwaggerEndpoint($"/swagger/{swaggerVersion}/swagger.json", swaggerTitle));
}

app.Run();
