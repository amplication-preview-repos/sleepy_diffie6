using Microsoft.AspNetCore.Mvc;

namespace ServicioDeGestiNMDica.APIs;

[ApiController()]
public class PacientesController : PacientesControllerBase
{
    public PacientesController(IPacientesService service)
        : base(service) { }
}
