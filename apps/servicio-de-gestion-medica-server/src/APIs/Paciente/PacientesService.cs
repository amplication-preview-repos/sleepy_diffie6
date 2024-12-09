using ServicioDeGestiNMDica.Infrastructure;

namespace ServicioDeGestiNMDica.APIs;

public class PacientesService : PacientesServiceBase
{
    public PacientesService(ServicioDeGestiNMDicaDbContext context)
        : base(context) { }
}
