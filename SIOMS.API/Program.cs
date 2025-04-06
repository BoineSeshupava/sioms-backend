// Entry Point for ASP.NET Core Web API
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/", () => "SIOMS Backend Running...");
app.Run();