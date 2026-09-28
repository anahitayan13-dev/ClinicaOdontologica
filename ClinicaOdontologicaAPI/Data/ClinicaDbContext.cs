using Microsoft.EntityFrameworkCore;
using ClinicaOdontologicaModelos;

namespace ClinicaOdontologicaAPI.Data
{
    public class ClinicaDbContext : DbContext
    {
        public ClinicaDbContext(DbContextOptions<ClinicaDbContext> options)
            : base(options)
        {
        }

       
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Odontologo> Odontologos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Consultorio> Consultorios { get; set; }
        public DbSet<Tratamiento> Tratamientos { get; set; }
        public DbSet<HistorialMedico> HistorialMedicos { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<DetalleCita> DetallesCitas { get; set; }
        public DbSet<Receta> Recetas { get; set; }
        public DbSet<Factura> Facturas { get; set; }
    }
}