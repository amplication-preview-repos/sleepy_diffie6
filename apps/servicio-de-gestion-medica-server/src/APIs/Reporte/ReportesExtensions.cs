using ServicioDeGestiNMDica.APIs.Dtos;
using ServicioDeGestiNMDica.Infrastructure.Models;

namespace ServicioDeGestiNMDica.APIs.Extensions;

public static class ReportesExtensions
{
    public static Reporte ToDto(this ReporteDbModel model)
    {
        return new Reporte
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ReporteDbModel ToModel(
        this ReporteUpdateInput updateDto,
        ReporteWhereUniqueInput uniqueId
    )
    {
        var reporte = new ReporteDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            reporte.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            reporte.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return reporte;
    }
}
