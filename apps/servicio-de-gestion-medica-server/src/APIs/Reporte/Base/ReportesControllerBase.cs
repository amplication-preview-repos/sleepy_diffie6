using Microsoft.AspNetCore.Mvc;
using ServicioDeGestiNMDica.APIs;
using ServicioDeGestiNMDica.APIs.Common;
using ServicioDeGestiNMDica.APIs.Dtos;
using ServicioDeGestiNMDica.APIs.Errors;

namespace ServicioDeGestiNMDica.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ReportesControllerBase : ControllerBase
{
    protected readonly IReportesService _service;

    public ReportesControllerBase(IReportesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Reporte
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Reporte>> CreateReporte(ReporteCreateInput input)
    {
        var reporte = await _service.CreateReporte(input);

        return CreatedAtAction(nameof(Reporte), new { id = reporte.Id }, reporte);
    }

    /// <summary>
    /// Delete one Reporte
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteReporte([FromRoute()] ReporteWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteReporte(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Reportes
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Reporte>>> Reportes(
        [FromQuery()] ReporteFindManyArgs filter
    )
    {
        return Ok(await _service.Reportes(filter));
    }

    /// <summary>
    /// Meta data about Reporte records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ReportesMeta(
        [FromQuery()] ReporteFindManyArgs filter
    )
    {
        return Ok(await _service.ReportesMeta(filter));
    }

    /// <summary>
    /// Get one Reporte
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Reporte>> Reporte([FromRoute()] ReporteWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Reporte(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Reporte
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateReporte(
        [FromRoute()] ReporteWhereUniqueInput uniqueId,
        [FromQuery()] ReporteUpdateInput reporteUpdateDto
    )
    {
        try
        {
            await _service.UpdateReporte(uniqueId, reporteUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
