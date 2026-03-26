using Mapster;

namespace SinteksApp.Application.Mappings;

public static class MapsterConfig
{
    public static void Register()
    {
        TypeAdapterConfig.GlobalSettings.Scan(typeof(MapsterConfig).Assembly);
    } 
}