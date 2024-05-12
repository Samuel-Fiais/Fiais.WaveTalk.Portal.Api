using Fiais.WaveTalk.Portal.Api.Middlewares;
using Fiais.WaveTalk.Portal.CrossCutting;
using Fiais.WaveTalk.Portal.Hub.Hub;

var builder = WebApplication.CreateBuilder(args);

ConfigurationIoc.LoadMapper(builder.Services);
ConfigurationIoc.LoadServices(builder.Services, builder.Configuration);
ConfigurationIoc.LoadDatabase(builder.Services);
ConfigurationIoc.LoadValidate(builder.Services);
ConfigurationIoc.LoadSwagger(builder.Services, builder.Configuration);

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
