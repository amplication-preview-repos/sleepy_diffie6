using ServicioDeGestiNMDica.Infrastructure;

namespace ServicioDeGestiNMDica.APIs;

public class GrFicosService : GrFicosServiceBase
{
    public GrFicosService(ServicioDeGestiNMDicaDbContext context)
        : base(context) { }
}
