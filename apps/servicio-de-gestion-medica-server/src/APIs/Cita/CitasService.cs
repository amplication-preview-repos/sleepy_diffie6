using ServicioDeGestiNMDica.Infrastructure;

namespace ServicioDeGestiNMDica.APIs;

public class CitasService : CitasServiceBase
{
    public CitasService(ServicioDeGestiNMDicaDbContext context)
        : base(context) { }
}
