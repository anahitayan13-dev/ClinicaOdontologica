using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace ClinicaOdontologicaModelos
{
    [Table("Pacientes")]
    public class Paciente
    {
        [Key]
        [Column("id_paciente")]
        public int IdPaciente { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("dni")]
        public string Dni { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("nombres")]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("apellidos")]
        public string Apellidos { get; set; }

        [Required]
        [Column("fecha_nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("email")]
        public string Email { get; set; }

        [MaxLength(10)]
        [Column("telefono")]
        public string? Telefono { get; set; }

        // Navegación historial médico
        [JsonIgnore]
        public virtual HistorialMedico? HistorialMedico { get; set; }

        // relación con citas
        [JsonIgnore]
        public List<Cita> Citas { get; set; } = new List<Cita>();
    }
}

