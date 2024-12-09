using ServicioDeGestiNMDica.APIs;

namespace ServicioDeGestiNMDica;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ICitasService, CitasService>();
        services.AddScoped<IGrFicosService, GrFicosService>();
        services.AddScoped<IPacientesService, PacientesService>();
        services.AddScoped<IReportesService, ReportesService>();
    }
}
