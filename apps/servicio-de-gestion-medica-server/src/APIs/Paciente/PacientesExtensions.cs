using ServicioDeGestiNMDica.APIs.Dtos;
using ServicioDeGestiNMDica.Infrastructure.Models;

namespace ServicioDeGestiNMDica.APIs.Extensions;

public static class PacientesExtensions
{
    public static Paciente ToDto(this PacienteDbModel model)
    {
        return new Paciente
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static PacienteDbModel ToModel(
        this PacienteUpdateInput updateDto,
        PacienteWhereUniqueInput uniqueId
    )
    {
        var paciente = new PacienteDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            paciente.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            paciente.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return paciente;
    }
}
