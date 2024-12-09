using Microsoft.EntityFrameworkCore;
using ServicioDeGestiNMDica.APIs;
using ServicioDeGestiNMDica.APIs.Common;
using ServicioDeGestiNMDica.APIs.Dtos;
using ServicioDeGestiNMDica.APIs.Errors;
using ServicioDeGestiNMDica.APIs.Extensions;
using ServicioDeGestiNMDica.Infrastructure;
using ServicioDeGestiNMDica.Infrastructure.Models;

namespace ServicioDeGestiNMDica.APIs;

public abstract class CitasServiceBase : ICitasService
{
    protected readonly ServicioDeGestiNMDicaDbContext _context;

    public CitasServiceBase(ServicioDeGestiNMDicaDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Cita
    /// </summary>
    public async Task<Cita> CreateCita(CitaCreateInput createDto)
    {
        var cita = new CitaDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            cita.Id = createDto.Id;
        }

        _context.Citas.Add(cita);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<CitaDbModel>(cita.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Cita
    /// </summary>
    public async Task DeleteCita(CitaWhereUniqueInput uniqueId)
    {
        var cita = await _context.Citas.FindAsync(uniqueId.Id);
        if (cita == null)
        {
            throw new NotFoundException();
        }

        _context.Citas.Remove(cita);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Citas
    /// </summary>
    public async Task<List<Cita>> Citas(CitaFindManyArgs findManyArgs)
    {
        var citas = await _context
            .Citas.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return citas.ConvertAll(cita => cita.ToDto());
    }

    /// <summary>
    /// Meta data about Cita records
    /// </summary>
    public async Task<MetadataDto> CitasMeta(CitaFindManyArgs findManyArgs)
    {
        var count = await _context.Citas.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Cita
    /// </summary>
    public async Task<Cita> Cita(CitaWhereUniqueInput uniqueId)
    {
        var citas = await this.Citas(
            new CitaFindManyArgs { Where = new CitaWhereInput { Id = uniqueId.Id } }
        );
        var cita = citas.FirstOrDefault();
        if (cita == null)
        {
            throw new NotFoundException();
        }

        return cita;
    }

    /// <summary>
    /// Update one Cita
    /// </summary>
    public async Task UpdateCita(CitaWhereUniqueInput uniqueId, CitaUpdateInput updateDto)
    {
        var cita = updateDto.ToModel(uniqueId);

        _context.Entry(cita).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Citas.Any(e => e.Id == cita.Id))
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
