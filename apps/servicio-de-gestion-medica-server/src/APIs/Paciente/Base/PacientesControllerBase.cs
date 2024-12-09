using Microsoft.AspNetCore.Mvc;
using ServicioDeGestiNMDica.APIs;
using ServicioDeGestiNMDica.APIs.Common;
using ServicioDeGestiNMDica.APIs.Dtos;
using ServicioDeGestiNMDica.APIs.Errors;

namespace ServicioDeGestiNMDica.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PacientesControllerBase : ControllerBase
{
    protected readonly IPacientesService _service;

    public PacientesControllerBase(IPacientesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Paciente
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Paciente>> CreatePaciente(PacienteCreateInput input)
    {
        var paciente = await _service.CreatePaciente(input);

        return CreatedAtAction(nameof(Paciente), new { id = paciente.Id }, paciente);
    }

    /// <summary>
    /// Delete one Paciente
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeletePaciente([FromRoute()] PacienteWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeletePaciente(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Pacientes
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Paciente>>> Pacientes(
        [FromQuery()] PacienteFindManyArgs filter
    )
    {
        return Ok(await _service.Pacientes(filter));
    }

    /// <summary>
    /// Meta data about Paciente records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PacientesMeta(
        [FromQuery()] PacienteFindManyArgs filter
    )
    {
        return Ok(await _service.PacientesMeta(filter));
    }

    /// <summary>
    /// Get one Paciente
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Paciente>> Paciente(
        [FromRoute()] PacienteWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Paciente(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Paciente
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdatePaciente(
        [FromRoute()] PacienteWhereUniqueInput uniqueId,
        [FromQuery()] PacienteUpdateInput pacienteUpdateDto
    )
    {
        try
        {
            await _service.UpdatePaciente(uniqueId, pacienteUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
