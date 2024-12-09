using ServicioDeGestiNMDica.APIs.Common;
using ServicioDeGestiNMDica.APIs.Dtos;

namespace ServicioDeGestiNMDica.APIs;

public interface IPacientesService
{
    /// <summary>
    /// Create one Paciente
    /// </summary>
    public Task<Paciente> CreatePaciente(PacienteCreateInput paciente);

    /// <summary>
    /// Delete one Paciente
    /// </summary>
    public Task DeletePaciente(PacienteWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Pacientes
    /// </summary>
    public Task<List<Paciente>> Pacientes(PacienteFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Paciente records
    /// </summary>
    public Task<MetadataDto> PacientesMeta(PacienteFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Paciente
    /// </summary>
    public Task<Paciente> Paciente(PacienteWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Paciente
    /// </summary>
    public Task UpdatePaciente(PacienteWhereUniqueInput uniqueId, PacienteUpdateInput updateDto);
}
