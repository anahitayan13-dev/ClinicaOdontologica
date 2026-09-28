using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClinicaOdontologicaModelos
{
   
    [Table("historialesmedicos")]
    public class HistorialMedico
    {
        [Key]
        [Column("id_historial")]
        public int IdHistorialMedico { get; set; }

        [Column("alergias")]
        [MaxLength(200)]
        public string alergia { get; set; } = "Ninguna";

        [Column("enfermedades_previas")]
        [MaxLength(200)]
        public string enfermedadesPrevias { get; set; } = "Ninguna";

        [Column("tipo_sangre")]
        [MaxLength(5)]
        public string tipoSangre { get; set; }

        [ForeignKey("paciente")]
        [Column("id_paciente")]
        public int IdPaciente { get; set; }
        [JsonIgnore]

        public Paciente? paciente { get; set; }
    }
    
}
