using Microsoft.EntityFrameworkCore;
using ServicioDeGestiNMDica.APIs;
using ServicioDeGestiNMDica.APIs.Common;
using ServicioDeGestiNMDica.APIs.Dtos;
using ServicioDeGestiNMDica.APIs.Errors;
using ServicioDeGestiNMDica.APIs.Extensions;
using ServicioDeGestiNMDica.Infrastructure;
using ServicioDeGestiNMDica.Infrastructure.Models;

namespace ServicioDeGestiNMDica.APIs;

public abstract class ReportesServiceBase : IReportesService
{
    protected readonly ServicioDeGestiNMDicaDbContext _context;

    public ReportesServiceBase(ServicioDeGestiNMDicaDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Reporte
    /// </summary>
    public async Task<Reporte> CreateReporte(ReporteCreateInput createDto)
    {
        var reporte = new ReporteDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            reporte.Id = createDto.Id;
        }

        _context.Reportes.Add(reporte);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ReporteDbModel>(reporte.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Reporte
    /// </summary>
    public async Task DeleteReporte(ReporteWhereUniqueInput uniqueId)
    {
        var reporte = await _context.Reportes.FindAsync(uniqueId.Id);
        if (reporte == null)
        {
            throw new NotFoundException();
        }

        _context.Reportes.Remove(reporte);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Reportes
    /// </summary>
    public async Task<List<Reporte>> Reportes(ReporteFindManyArgs findManyArgs)
    {
        var reportes = await _context
            .Reportes.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return reportes.ConvertAll(reporte => reporte.ToDto());
    }

    /// <summary>
    /// Meta data about Reporte records
    /// </summary>
    public async Task<MetadataDto> ReportesMeta(ReporteFindManyArgs findManyArgs)
    {
        var count = await _context.Reportes.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Reporte
    /// </summary>
    public async Task<Reporte> Reporte(ReporteWhereUniqueInput uniqueId)
    {
        var reportes = await this.Reportes(
            new ReporteFindManyArgs { Where = new ReporteWhereInput { Id = uniqueId.Id } }
        );
        var reporte = reportes.FirstOrDefault();
        if (reporte == null)
        {
            throw new NotFoundException();
        }

        return reporte;
    }

    /// <summary>
    /// Update one Reporte
    /// </summary>
    public async Task UpdateReporte(ReporteWhereUniqueInput uniqueId, ReporteUpdateInput updateDto)
    {
        var reporte = updateDto.ToModel(uniqueId);

        _context.Entry(reporte).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Reportes.Any(e => e.Id == reporte.Id))
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
