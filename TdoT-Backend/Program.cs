using Microsoft.AspNetCore.Authentication;
using TdoT_Backend.Middleware;
using TdoT_Backend.Services;
using AuthenticationMiddleware = TdoT_Backend.Middleware.AuthenticationMiddleware;


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
builder.Services.AddScoped<AdminService>();

builder.Services.AddAuthentication("AdminScheme")
    .AddScheme<AuthenticationSchemeOptions, AuthenticationMiddleware>("AdminScheme", options => { });

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
