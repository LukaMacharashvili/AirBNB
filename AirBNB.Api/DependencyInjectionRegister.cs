using AirBNB.Api.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using AirBNB.Api.Common.Mapping;

namespace AirBNB.Api;

public static class DependencyInjectionRegister
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddHttpContextAccessor();
        services.AddSingleton<ProblemDetailsFactory, AirBNBProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}