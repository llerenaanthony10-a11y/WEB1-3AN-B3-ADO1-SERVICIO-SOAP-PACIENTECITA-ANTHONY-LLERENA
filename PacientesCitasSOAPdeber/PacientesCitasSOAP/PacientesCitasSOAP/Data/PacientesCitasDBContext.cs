using PacientesCitasSOAP.Models;
using Microsoft.EntityFrameworkCore;

namespace PacientesCitasSOAP.Data
{
    public class PacientesCitasDBContext : DbContext
    {
        public PacientesCitasDBContext(DbContextOptions<PacientesCitasDBContext> options)
            : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<Cita> Citas { get; set; }
    }
}
