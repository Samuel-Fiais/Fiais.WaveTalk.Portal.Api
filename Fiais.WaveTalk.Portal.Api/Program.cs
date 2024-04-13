using Fiais.WaveTalk.Portal.Api.Middlewares;
using Fiais.WaveTalk.Portal.Configuration;

var builder = WebApplication.CreateBuilder(args);

Configuration.LoadMapper(builder.Services);
Configuration.LoadServices(builder.Services, builder.Configuration);
Configuration.LoadDatabase(builder.Services);
Configuration.LoadValidate(builder.Services);
Configuration.LoadSwagger(builder.Services, builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(policy => policy
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

app.UseSession();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<SessionMiddleware>();

app.MapControllers();

app.Run();
