using PacientesCitasSOAP.Models;
using CoreWCF;

namespace PacientesCitasSOAP.Services
{
    [ServiceContract] // Contrato SOAP: esta interfaz define las operaciones expuestas
    public interface IPacienteCitaService
    {
        [OperationContract]
        List<Paciente> ObtenerPacientes();

        [OperationContract]
        List<Cita> ObtenerCitas();

        [OperationContract]
        Cita? ObtenerCita(int id);

        [OperationContract]
        Cita AgregarCita(Cita cita);

        [OperationContract]
        Cita? ActualizarCita(Cita cita);

        [OperationContract]
        bool EliminarCita(int id);

        [OperationContract]
        List<Cita> ObtenerCitaPorTratamiento(string tratamiento);

        [OperationContract]
        List<Cita> ObtenerCitaPorCedula(string cedula);
    }
}
