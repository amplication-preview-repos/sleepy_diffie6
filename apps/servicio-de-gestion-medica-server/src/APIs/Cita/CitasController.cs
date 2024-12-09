using Microsoft.AspNetCore.Mvc;

namespace ServicioDeGestiNMDica.APIs;

[ApiController()]
public class CitasController : CitasControllerBase
{
    public CitasController(ICitasService service)
        : base(service) { }
}
