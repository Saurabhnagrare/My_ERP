using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ERP API",
        Version = "v1",
        Description = "ERP Management System API"
    });
});

var app = builder.Build();

// Swagger
app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "ERP API v1");
    options.RoutePrefix = string.Empty;
    options.DocumentTitle = "ERP API Documentation";
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();