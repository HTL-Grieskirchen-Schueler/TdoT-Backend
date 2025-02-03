using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using TdoT_Backend.Middleware;
using TdoT_Backend.Services;
using AuthenticationMiddleware = TdoT_Backend.Middleware.AuthenticationMiddleware;


string corsKey = "_myCorsKey";

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(o =>
    {
        o.AddSecurityDefinition("PasswordHeader", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Name = "password",
            Type = SecuritySchemeType.ApiKey,
            Description = "Enter sha256 hash for authentication"
        });
    })
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

app.UseDefaultFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Data/html/")),
    RequestPath = "/admin-panel", 
});

app.Map("/", () => Results.Redirect("/admin-panel/index.html"));

app.MapControllers();

app.UseCors(corsKey);
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
