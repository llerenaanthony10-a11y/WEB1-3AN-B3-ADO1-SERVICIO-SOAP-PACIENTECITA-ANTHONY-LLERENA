using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PacientesCitasSOAP.Models
{
    [DataContract]
    public class Paciente
    {
        [Key]
        [DataMember(Order = 1)]
        public int IdPaciente { get; set; }

        [DataMember(Order = 2)]
        public string Cedula { get; set; } = string.Empty;

        [DataMember(Order = 3)]
        public string Nombre { get; set; } = string.Empty;

        [DataMember(Order = 4)]
        public string Apellido { get; set; } = string.Empty;

        [DataMember(Order = 5)]
        public string? Telefono { get; set; }

        [DataMember(Order = 6)]
        public bool Estado { get; set; }

        [IgnoreDataMember]
        public List<Cita>? Citas { get; set; }
    }
}