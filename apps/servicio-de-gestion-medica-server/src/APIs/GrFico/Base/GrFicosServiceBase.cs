using Microsoft.EntityFrameworkCore;
using ServicioDeGestiNMDica.APIs;
using ServicioDeGestiNMDica.APIs.Common;
using ServicioDeGestiNMDica.APIs.Dtos;
using ServicioDeGestiNMDica.APIs.Errors;
using ServicioDeGestiNMDica.APIs.Extensions;
using ServicioDeGestiNMDica.Infrastructure;
using ServicioDeGestiNMDica.Infrastructure.Models;

namespace ServicioDeGestiNMDica.APIs;

public abstract class GrFicosServiceBase : IGrFicosService
{
    protected readonly ServicioDeGestiNMDicaDbContext _context;

    public GrFicosServiceBase(ServicioDeGestiNMDicaDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Gráfico
    /// </summary>
    public async Task<GrFico> CreateGrFico(GrFicoCreateInput createDto)
    {
        var grFico = new GrFicoDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            grFico.Id = createDto.Id;
        }

        _context.GrFicos.Add(grFico);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<GrFicoDbModel>(grFico.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Gráfico
    /// </summary>
    public async Task DeleteGrFico(GrFicoWhereUniqueInput uniqueId)
    {
        var grFico = await _context.GrFicos.FindAsync(uniqueId.Id);
        if (grFico == null)
        {
            throw new NotFoundException();
        }

        _context.GrFicos.Remove(grFico);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Gráficos
    /// </summary>
    public async Task<List<GrFico>> GrFicos(GrFicoFindManyArgs findManyArgs)
    {
        var grFicos = await _context
            .GrFicos.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return grFicos.ConvertAll(grFico => grFico.ToDto());
    }

    /// <summary>
    /// Meta data about Gráfico records
    /// </summary>
    public async Task<MetadataDto> GrFicosMeta(GrFicoFindManyArgs findManyArgs)
    {
        var count = await _context.GrFicos.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Gráfico
    /// </summary>
    public async Task<GrFico> GrFico(GrFicoWhereUniqueInput uniqueId)
    {
        var grFicos = await this.GrFicos(
            new GrFicoFindManyArgs { Where = new GrFicoWhereInput { Id = uniqueId.Id } }
        );
        var grFico = grFicos.FirstOrDefault();
        if (grFico == null)
        {
            throw new NotFoundException();
        }

        return grFico;
    }

    /// <summary>
    /// Update one Gráfico
    /// </summary>
    public async Task UpdateGrFico(GrFicoWhereUniqueInput uniqueId, GrFicoUpdateInput updateDto)
    {
        var grFico = updateDto.ToModel(uniqueId);

        _context.Entry(grFico).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.GrFicos.Any(e => e.Id == grFico.Id))
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
