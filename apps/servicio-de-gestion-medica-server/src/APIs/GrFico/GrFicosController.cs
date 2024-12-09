using Microsoft.AspNetCore.Mvc;

namespace ServicioDeGestiNMDica.APIs;

[ApiController()]
public class GrFicosController : GrFicosControllerBase
{
    public GrFicosController(IGrFicosService service)
        : base(service) { }
}
