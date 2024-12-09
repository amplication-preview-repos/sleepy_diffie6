using Microsoft.AspNetCore.Mvc;

namespace ServicioDeGestiNMDica.APIs;

[ApiController()]
public class ReportesController : ReportesControllerBase
{
    public ReportesController(IReportesService service)
        : base(service) { }
}
