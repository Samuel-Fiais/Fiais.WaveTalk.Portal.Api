using AutoMapper;
using Fiais.WaveTalk.Portal.Application.Helpers;
using Fiais.WaveTalk.Portal.Domain.Context;
using Fiais.WaveTalk.Portal.Domain.Entity;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.Infra.Data.Context;
using Fiais.WaveTalk.Portal.Infra.Data.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetChatRooms;
using Fiais.WaveTalk.Portal.UseCase.Contracts.Message;
using Fiais.WaveTalk.Portal.UseCase.Contracts.Message.GetMessageByChatRoom;
using Fiais.WaveTalk.Portal.UseCase.Contracts.User;
using Fiais.WaveTalk.Portal.UseCase.UseCases.ChatRoom;
using Fiais.WaveTalk.Portal.UseCase.UseCases.Message;
using Fiais.WaveTalk.Portal.UseCase.UseCases.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Fiais.WaveTalk.Portal.Configuration;

public static class Configuration
{
    public static void LoadMapper(IServiceCollection services)
    {
        var autoMapper = new MapperConfiguration(config =>
        {
            config.CreateMap<ChatRoom, GetChatRoomsDto>();
            config.CreateMap<Message, GetMessageByChatRoomDto>()
                .ForMember(x => x.Username, x => x.MapFrom(y => y.User!.Username));
        });

        var mapper = autoMapper.CreateMapper();
        services.AddSingleton(mapper);
    }

    public static void LoadServices(IServiceCollection services, IConfigurationBuilder config)
    {
        services.TryAddSingleton(config);
        services.AddDistributedMemoryCache();
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromDays(1);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });
        services.AddHttpContextAccessor();

        services.AddScoped<IUserModule, UserModule>();
        services.AddScoped<IChatRoomModule, ChatRoomModule>();
        services.AddScoped<IMessageModule, MessageModule>();
        services.AddScoped<IUserContext, UserContext>();
        services.AddScoped<IRepositoryModule, RepositoryModule>();
    }

    public static void LoadDatabase(IServiceCollection services)
    {
        var connection = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? string.Empty;

        services.AddDbContext<ContextDatabase>(options => { options.UseSqlite(connection); });

        using var context = services.BuildServiceProvider()
            .GetRequiredService<ContextDatabase>();

        context.Database.Migrate();
    }

    public static void LoadValidate(IServiceCollection services)
    {
        services.AddControllers().ConfigureApiBehaviorOptions(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var errors = context.ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage);
                var result = new BadRequestObjectResult(new ResponseApi(false, "Invalid model state", errors));
                return result;
            };
        });
    }

    public static void LoadSwagger(IServiceCollection services, IConfiguration config)
    {
        services.AddSwaggerGen(c => c.LoadOpenApiOptions())
            .AddAuthentication(o => o.LoadAuthenticationOptions())
            .AddJwtBearer(o => o.LoadJwtBearerOptions(config));
    }

    private static void LoadOpenApiOptions(this SwaggerGenOptions options)
    {
        var securityScheme = new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme."
        };

        var securityReq = new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        };

        var contact = new OpenApiContact()
        {
            Name = "Fiais Tech",
            Email = "samuelfiais.dev@gmail.com",
            Url = new Uri("mailto:samuelfiais.dev@gmail.com")
        };

        var info = new OpenApiInfo()
        {
            Version = "v1",
            Title = "Fiais WaveTalk Portal API",
            Description = "API designed to manage the Fiais WaveTalk Portal",
            Contact = contact,
        };

        options.SwaggerDoc("v1", info);
        options.AddSecurityDefinition("Bearer", securityScheme);
        options.AddSecurityRequirement(securityReq);
    }

    private static void LoadAuthenticationOptions(this AuthenticationOptions o)
    {
        o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }

    private static void LoadJwtBearerOptions(this JwtBearerOptions o, IConfiguration config)
    {
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true
        };
    }
}