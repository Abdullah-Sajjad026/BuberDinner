using System.Reflection;
using Microsoft.OpenApi.Models;

using BuberDinner.Application;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.AddApplication().AddInfrastructure();
    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(s =>
    {
        s.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Buber Dinner API",
            Description = "This is the api explorer for BuberDinner",
            Version = "v1"
        });

        var xmlDocFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlDocPath = Path.Join(AppContext.BaseDirectory, xmlDocFile);
        s.IncludeXmlComments(xmlDocPath);
    });
}

var app = builder.Build();
{

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();

    app.MapControllers();
}
app.Run();
