using ServicioDeGestiNMDica.APIs.Common;
using ServicioDeGestiNMDica.APIs.Dtos;

namespace ServicioDeGestiNMDica.APIs;

public interface IReportesService
{
    /// <summary>
    /// Create one Reporte
    /// </summary>
    public Task<Reporte> CreateReporte(ReporteCreateInput reporte);

    /// <summary>
    /// Delete one Reporte
    /// </summary>
    public Task DeleteReporte(ReporteWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Reportes
    /// </summary>
    public Task<List<Reporte>> Reportes(ReporteFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Reporte records
    /// </summary>
    public Task<MetadataDto> ReportesMeta(ReporteFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Reporte
    /// </summary>
    public Task<Reporte> Reporte(ReporteWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Reporte
    /// </summary>
    public Task UpdateReporte(ReporteWhereUniqueInput uniqueId, ReporteUpdateInput updateDto);
}
