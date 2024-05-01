using Fiais.WaveTalk.Portal.Api.Middlewares;
using Fiais.WaveTalk.Portal.Configuration;
using Fiais.WaveTalk.Portal.Hub.Hub;

var builder = WebApplication.CreateBuilder(args);

Configuration.LoadMapper(builder.Services);
Configuration.LoadServices(builder.Services, builder.Configuration);
Configuration.LoadDatabase(builder.Services);
Configuration.LoadValidate(builder.Services);
Configuration.LoadSwagger(builder.Services, builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("reactApp", corsPolicyBuilder =>
    {
        corsPolicyBuilder.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .SetIsOriginAllowed((host) => true);
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("reactApp");

app.UseSession();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<SessionMiddleware>();

app.MapControllers();

app.MapHub<ChatHub>("/chat-hub");

app.Run();
