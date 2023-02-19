using Microsoft.AspNetCore.Mvc.Versioning;
using VirtualStore.Infrastructure.API;
using VirtualStore.Infrastructure.API.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 1);
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.ReportApiVersions = true;
    opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                    new HeaderApiVersionReader("x-api-version"),
                                                    new MediaTypeApiVersionReader("x-api-version"));
});

var AllowAll = "AllowAllSpecificationsCors";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowAll, policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://127.0.0.1:3000")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var startup = new Startup();

startup.ConfigureContainer(builder.Services, builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<JwtMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(AllowAll);

app.Run();

