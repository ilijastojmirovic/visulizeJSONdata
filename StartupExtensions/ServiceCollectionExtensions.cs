using VisualizeJSONData.Services;

namespace VisualizeJSONData.StartupExtensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddHttpClient<ITimeEntryService, TimeEntryService>();
        return services;
    }
}