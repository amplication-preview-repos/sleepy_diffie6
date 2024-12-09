using Microsoft.AspNetCore.Mvc;
using ServicioDeGestiNMDica.APIs;
using ServicioDeGestiNMDica.APIs.Common;
using ServicioDeGestiNMDica.APIs.Dtos;
using ServicioDeGestiNMDica.APIs.Errors;

namespace ServicioDeGestiNMDica.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class CitasControllerBase : ControllerBase
{
    protected readonly ICitasService _service;

    public CitasControllerBase(ICitasService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Cita
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Cita>> CreateCita(CitaCreateInput input)
    {
        var cita = await _service.CreateCita(input);

        return CreatedAtAction(nameof(Cita), new { id = cita.Id }, cita);
    }

    /// <summary>
    /// Delete one Cita
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteCita([FromRoute()] CitaWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteCita(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Citas
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Cita>>> Citas([FromQuery()] CitaFindManyArgs filter)
    {
        return Ok(await _service.Citas(filter));
    }

    /// <summary>
    /// Meta data about Cita records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> CitasMeta([FromQuery()] CitaFindManyArgs filter)
    {
        return Ok(await _service.CitasMeta(filter));
    }

    /// <summary>
    /// Get one Cita
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Cita>> Cita([FromRoute()] CitaWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Cita(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Cita
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateCita(
        [FromRoute()] CitaWhereUniqueInput uniqueId,
        [FromQuery()] CitaUpdateInput citaUpdateDto
    )
    {
        try
        {
            await _service.UpdateCita(uniqueId, citaUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
