using AspNet_micro_app.Configurations;
using AspNet_micro_app.Extensions;
using AspNet_micro_app.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddCustomMiddlewares();

builder.Host.UseSerilogConf(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<ErrorMiddleware>();
app.UseMiddleware<MaintenanceMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();