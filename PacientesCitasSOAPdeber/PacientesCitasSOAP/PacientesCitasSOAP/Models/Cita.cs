using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace PacientesCitasSOAP.Models
{
    [DataContract]
    public class Cita
    {
        [Key]
        [DataMember(Order = 1)]
        public int IdCita { get; set; }

        [Column(TypeName = "date")]
        [DataMember(Order = 2)]
        public DateTime Fecha { get; set; }

        [DataMember(Order = 3)]
        public DateTime Hora { get; set; }

        [DataMember(Order = 4)]
        public string Motivo { get; set; } = string.Empty;

        [DataMember(Order = 5)]
        public string Tratamiento { get; set; } = string.Empty;

        [DataMember(Order = 6)]
        public bool Estado { get; set; }

        [DataMember(Order = 7)]
        public int IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        [IgnoreDataMember]
        public Paciente? Paciente { get; set; }
    }
}