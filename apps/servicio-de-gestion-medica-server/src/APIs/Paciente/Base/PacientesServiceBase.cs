using Microsoft.EntityFrameworkCore;
using ServicioDeGestiNMDica.APIs;
using ServicioDeGestiNMDica.APIs.Common;
using ServicioDeGestiNMDica.APIs.Dtos;
using ServicioDeGestiNMDica.APIs.Errors;
using ServicioDeGestiNMDica.APIs.Extensions;
using ServicioDeGestiNMDica.Infrastructure;
using ServicioDeGestiNMDica.Infrastructure.Models;

namespace ServicioDeGestiNMDica.APIs;

public abstract class PacientesServiceBase : IPacientesService
{
    protected readonly ServicioDeGestiNMDicaDbContext _context;

    public PacientesServiceBase(ServicioDeGestiNMDicaDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Paciente
    /// </summary>
    public async Task<Paciente> CreatePaciente(PacienteCreateInput createDto)
    {
        var paciente = new PacienteDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            paciente.Id = createDto.Id;
        }

        _context.Pacientes.Add(paciente);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PacienteDbModel>(paciente.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Paciente
    /// </summary>
    public async Task DeletePaciente(PacienteWhereUniqueInput uniqueId)
    {
        var paciente = await _context.Pacientes.FindAsync(uniqueId.Id);
        if (paciente == null)
        {
            throw new NotFoundException();
        }

        _context.Pacientes.Remove(paciente);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Pacientes
    /// </summary>
    public async Task<List<Paciente>> Pacientes(PacienteFindManyArgs findManyArgs)
    {
        var pacientes = await _context
            .Pacientes.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return pacientes.ConvertAll(paciente => paciente.ToDto());
    }

    /// <summary>
    /// Meta data about Paciente records
    /// </summary>
    public async Task<MetadataDto> PacientesMeta(PacienteFindManyArgs findManyArgs)
    {
        var count = await _context.Pacientes.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Paciente
    /// </summary>
    public async Task<Paciente> Paciente(PacienteWhereUniqueInput uniqueId)
    {
        var pacientes = await this.Pacientes(
            new PacienteFindManyArgs { Where = new PacienteWhereInput { Id = uniqueId.Id } }
        );
        var paciente = pacientes.FirstOrDefault();
        if (paciente == null)
        {
            throw new NotFoundException();
        }

        return paciente;
    }

    /// <summary>
    /// Update one Paciente
    /// </summary>
    public async Task UpdatePaciente(
        PacienteWhereUniqueInput uniqueId,
        PacienteUpdateInput updateDto
    )
    {
        var paciente = updateDto.ToModel(uniqueId);

        _context.Entry(paciente).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Pacientes.Any(e => e.Id == paciente.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
