using ServicioDeGestiNMDica.APIs.Common;
using ServicioDeGestiNMDica.APIs.Dtos;

namespace ServicioDeGestiNMDica.APIs;

public interface IGrFicosService
{
    /// <summary>
    /// Create one Gráfico
    /// </summary>
    public Task<GrFico> CreateGrFico(GrFicoCreateInput grfico);

    /// <summary>
    /// Delete one Gráfico
    /// </summary>
    public Task DeleteGrFico(GrFicoWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Gráficos
    /// </summary>
    public Task<List<GrFico>> GrFicos(GrFicoFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Gráfico records
    /// </summary>
    public Task<MetadataDto> GrFicosMeta(GrFicoFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Gráfico
    /// </summary>
    public Task<GrFico> GrFico(GrFicoWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Gráfico
    /// </summary>
    public Task UpdateGrFico(GrFicoWhereUniqueInput uniqueId, GrFicoUpdateInput updateDto);
}
