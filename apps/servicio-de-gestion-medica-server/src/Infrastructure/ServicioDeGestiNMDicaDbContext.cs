using Microsoft.EntityFrameworkCore;
using ServicioDeGestiNMDica.Infrastructure.Models;

namespace ServicioDeGestiNMDica.Infrastructure;

public class ServicioDeGestiNMDicaDbContext : DbContext
{
    public ServicioDeGestiNMDicaDbContext(DbContextOptions<ServicioDeGestiNMDicaDbContext> options)
        : base(options) { }

    public DbSet<PacienteDbModel> Pacientes { get; set; }

    public DbSet<CitaDbModel> Citas { get; set; }

    public DbSet<GrFicoDbModel> GrFicos { get; set; }

    public DbSet<ReporteDbModel> Reportes { get; set; }
}
