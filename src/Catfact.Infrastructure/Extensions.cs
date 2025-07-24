using Catfact.Application.Abstractions;
using Catfact.Application.Commands;
using Catfact.Application.Commands.Handlers;
using Catfact.Application.Queries;
using Catfact.Core.Abstractions;
using Catfact.Core.Models;
using Catfact.Core.Repositories;
using Catfact.Infrastructure.Exceptions;
using Catfact.Infrastructure.Handlers;
using Catfact.Infrastructure.Repositories;
using Catfact.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Catfact.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient("client", (serviceProvider, client) =>
        {
            var config = serviceProvider.GetRequiredService<IConfiguration>();
            var baseAddress = config["BaseAddress"];
            client.BaseAddress = new Uri(baseAddress);
        });
        services.AddControllers();
        services.AddHttpContextAccessor();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(swagger =>
        {
            swagger.EnableAnnotations();
            swagger.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Catfact Api",
                Version = "v1"
            });
        });

        services.AddCors(options =>
        {
            options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        });

        services.AddSingleton<ExceptionMiddleware>();
        services.AddScoped<ICatRepository, CatRepository>();
        services.AddScoped<ICatService, CatService>();
        services.AddScoped<IQueryHandler<GetCats, List<Cat>>, GetCatsHandler>();
        services.AddScoped<ICommandHandler<CreateCat>, CreateCatHandler>();

        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseCors("Open");
        app.MapControllers();

        return app;
    }
}