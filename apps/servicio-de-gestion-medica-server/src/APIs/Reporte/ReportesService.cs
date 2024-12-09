using ServicioDeGestiNMDica.Infrastructure;

namespace ServicioDeGestiNMDica.APIs;

public class ReportesService : ReportesServiceBase
{
    public ReportesService(ServicioDeGestiNMDicaDbContext context)
        : base(context) { }
}
