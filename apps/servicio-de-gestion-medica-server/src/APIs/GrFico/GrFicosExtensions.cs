using ServicioDeGestiNMDica.APIs.Dtos;
using ServicioDeGestiNMDica.Infrastructure.Models;

namespace ServicioDeGestiNMDica.APIs.Extensions;

public static class GrFicosExtensions
{
    public static GrFico ToDto(this GrFicoDbModel model)
    {
        return new GrFico
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static GrFicoDbModel ToModel(
        this GrFicoUpdateInput updateDto,
        GrFicoWhereUniqueInput uniqueId
    )
    {
        var grFico = new GrFicoDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            grFico.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            grFico.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return grFico;
    }
}
