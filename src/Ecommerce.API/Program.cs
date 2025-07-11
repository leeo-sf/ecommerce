using Ecommerce.Infra.Ioc.Config;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthenticationSwagger();

builder.Services.AddConfigControllers();

builder.Services.AddVersioning();

builder.Services.ConfigureAppDependencies(configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
