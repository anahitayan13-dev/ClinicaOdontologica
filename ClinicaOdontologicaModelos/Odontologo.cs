using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClinicaOdontologicaModelos
{
    [Table("odontologos")]
    public class Odontologo
    {
        [Key]
        [Column("id_odontologo")]
        public int IdOdontologo { get; set; }

        [Column("nombres")]
        [MaxLength(50)]
        [Required]
        public string Nombres { get; set; }

        [Column("apellidos")]
        [MaxLength(50)]
        [Required]
        public string Apellidos { get; set; }

        [Column("registro_medico")]
        [MaxLength(20)]
        [Required]
        public string RegistroMedico { get; set; }

        [Column("id_especialidad")]
        [Required]
        public int IdEspecialidad { get; set; }

        // Navegación
        [ForeignKey("IdEspecialidad")]
        [JsonIgnore]
        public Especialidad? Especialidad { get; set; }

        // relación con citas
        [JsonIgnore]
        public List<Cita> Cita { get; set; } = new List<Cita>();
    }
}