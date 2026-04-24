using CentroSalud.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CentroSalud.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // =========================
    // DbSets (Tablas)
    // =========================

    public DbSet<Medico> Medicos => Set<Medico>();
    public DbSet<Empleado> Empleados => Set<Empleado>();
    public DbSet<Paciente> Pacientes => Set<Paciente>();
    public DbSet<Sustitucion> Sustituciones => Set<Sustitucion>();
    public DbSet<Horario> Horarios => Set<Horario>();
    public DbSet<Vacacion> Vacaciones => Set<Vacacion>();

    // =========================
    // Configuración de relaciones
    // =========================

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 🔄 Sustituciones (relación doble con Medico)
        modelBuilder.Entity<Sustitucion>()
    .HasOne(s => s.MedicoSustituto)
    .WithMany(m => m.SustitucionesComoSustituto)
    .HasForeignKey(s => s.MedicoSustitutoId)
    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Sustitucion>()
            .HasOne(s => s.MedicoReemplazado)
            .WithMany(m => m.SustitucionesComoReemplazado)
            .HasForeignKey(s => s.MedicoReemplazadoId)
            .OnDelete(DeleteBehavior.Restrict);

        // 🏥 Paciente → Medico
        modelBuilder.Entity<Paciente>()
            .HasOne(p => p.Medico)
            .WithMany()
            .HasForeignKey(p => p.MedicoId)
            .OnDelete(DeleteBehavior.Restrict);

        // ⏰ Horario → Medico
        modelBuilder.Entity<Horario>()
        .HasOne(h => h.Medico)           
        .WithMany(m => m.Horarios)     
        .HasForeignKey(h => h.MedicoId)   
        .OnDelete(DeleteBehavior.Cascade);

        // 🌴 Vacaciones → Empleado
        modelBuilder.Entity<Vacacion>()
            .HasOne(v => v.Empleado)
            .WithMany(e => e.Vacaciones)
            .HasForeignKey(v => v.EmpleadoId)
            .OnDelete(DeleteBehavior.Restrict);

        // 🌴 Vacaciones → Medico
        modelBuilder.Entity<Vacacion>()
            .HasOne(v => v.Medico)
            .WithMany(m => m.Vacaciones)
            .HasForeignKey(v => v.MedicoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}