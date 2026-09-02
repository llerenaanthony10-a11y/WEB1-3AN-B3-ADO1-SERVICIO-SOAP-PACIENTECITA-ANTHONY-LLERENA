using PacientesCitasSOAP.Data;
using PacientesCitasSOAP.Models;
using CoreWCF;

namespace PacientesCitasSOAP.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)] // Una instancia nueva por cada llamada
    public class PacienteCitaService : IPacienteCitaService
    {
        private readonly PacientesCitasDBContext _dbContext;

        public PacienteCitaService(PacientesCitasDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Paciente> ObtenerPacientes()
        {
            return _dbContext.Pacientes.ToList();
        }

        public List<Cita> ObtenerCitas()
        {
            return _dbContext.Citas.ToList();
        }

        public Cita? ObtenerCita(int id)
        {
            return _dbContext.Citas.FirstOrDefault(c => c.IdCita == id);
        }

        public Cita AgregarCita(Cita cita)
        {
            _dbContext.Citas.Add(cita);
            _dbContext.SaveChanges();
            return cita;
        }

        public Cita? ActualizarCita(Cita cita)
        {
            var citaExistente = _dbContext.Citas.Find(cita.IdCita);

            if (citaExistente == null) return null;

            citaExistente.Fecha = cita.Fecha;
            citaExistente.Hora = cita.Hora;
            citaExistente.Motivo = cita.Motivo;
            citaExistente.Tratamiento = cita.Tratamiento;
            citaExistente.Estado = cita.Estado;
            citaExistente.IdPaciente = cita.IdPaciente;

            _dbContext.SaveChanges();

            return citaExistente;
        }

        public bool EliminarCita(int id)
        {
            var cita = _dbContext.Citas.Find(id);
            if (cita == null) return false;

            _dbContext.Citas.Remove(cita);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Cita> ObtenerCitaPorTratamiento(string tratamiento)
        {
            return _dbContext.Citas
                .Where(c => c.Tratamiento.Contains(tratamiento))
                .ToList();
        }

        public List<Cita> ObtenerCitaPorCedula(string cedula)
        {
            return _dbContext.Citas
                .Where(c => c.Paciente != null && c.Paciente.Cedula == cedula)
                .ToList();
        }
    }
}
