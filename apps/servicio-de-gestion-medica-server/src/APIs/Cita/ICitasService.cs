using ServicioDeGestiNMDica.APIs.Common;
using ServicioDeGestiNMDica.APIs.Dtos;

namespace ServicioDeGestiNMDica.APIs;

public interface ICitasService
{
    /// <summary>
    /// Create one Cita
    /// </summary>
    public Task<Cita> CreateCita(CitaCreateInput cita);

    /// <summary>
    /// Delete one Cita
    /// </summary>
    public Task DeleteCita(CitaWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Citas
    /// </summary>
    public Task<List<Cita>> Citas(CitaFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Cita records
    /// </summary>
    public Task<MetadataDto> CitasMeta(CitaFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Cita
    /// </summary>
    public Task<Cita> Cita(CitaWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Cita
    /// </summary>
    public Task UpdateCita(CitaWhereUniqueInput uniqueId, CitaUpdateInput updateDto);
}
