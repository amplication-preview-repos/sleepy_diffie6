using Microsoft.AspNetCore.Mvc;
using ServicioDeGestiNMDica.APIs;
using ServicioDeGestiNMDica.APIs.Common;
using ServicioDeGestiNMDica.APIs.Dtos;
using ServicioDeGestiNMDica.APIs.Errors;

namespace ServicioDeGestiNMDica.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class GrFicosControllerBase : ControllerBase
{
    protected readonly IGrFicosService _service;

    public GrFicosControllerBase(IGrFicosService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Gráfico
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<GrFico>> CreateGrFico(GrFicoCreateInput input)
    {
        var grFico = await _service.CreateGrFico(input);

        return CreatedAtAction(nameof(GrFico), new { id = grFico.Id }, grFico);
    }

    /// <summary>
    /// Delete one Gráfico
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteGrFico([FromRoute()] GrFicoWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteGrFico(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Gráficos
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<GrFico>>> GrFicos([FromQuery()] GrFicoFindManyArgs filter)
    {
        return Ok(await _service.GrFicos(filter));
    }

    /// <summary>
    /// Meta data about Gráfico records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> GrFicosMeta(
        [FromQuery()] GrFicoFindManyArgs filter
    )
    {
        return Ok(await _service.GrFicosMeta(filter));
    }

    /// <summary>
    /// Get one Gráfico
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<GrFico>> GrFico([FromRoute()] GrFicoWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.GrFico(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Gráfico
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateGrFico(
        [FromRoute()] GrFicoWhereUniqueInput uniqueId,
        [FromQuery()] GrFicoUpdateInput grFicoUpdateDto
    )
    {
        try
        {
            await _service.UpdateGrFico(uniqueId, grFicoUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
