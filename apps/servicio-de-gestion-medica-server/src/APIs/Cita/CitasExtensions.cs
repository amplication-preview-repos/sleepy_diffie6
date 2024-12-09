using ServicioDeGestiNMDica.APIs.Dtos;
using ServicioDeGestiNMDica.Infrastructure.Models;

namespace ServicioDeGestiNMDica.APIs.Extensions;

public static class CitasExtensions
{
    public static Cita ToDto(this CitaDbModel model)
    {
        return new Cita
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static CitaDbModel ToModel(this CitaUpdateInput updateDto, CitaWhereUniqueInput uniqueId)
    {
        var cita = new CitaDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            cita.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            cita.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return cita;
    }
}
