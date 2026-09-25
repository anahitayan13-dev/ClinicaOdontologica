using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClinicaOdontologicaModelos
{
    [Table("citas")]
    public class Cita
    {
        [Key]
        [Column("id_cita")]
        public int IdCita { get; set; }

        [Column("fecha_cita")]
        [Required]
        public DateTime FechaCita { get; set; }

        [Column("motivo")]
        [MaxLength(200)]
        public string Motivo { get; set; }

        [Column("estado_cita")]
        [MaxLength(20)]
        public string EstadoCita { get; set; } = "Pendiente";

        [Column("id_paciente")]
        [Required]
        public int IdPaciente { get; set; }

        [Column("id_odontologo")]
        [Required]
        public int IdOdontologo { get; set; }

        [Column("id_consultorio")]
        [Required]
        public int IdConsultorio { get; set; }

        // Navegación
        [JsonIgnore]
        [ForeignKey("IdPaciente")]
        public Paciente? Paciente { get; set; }

        [JsonIgnore]
        [ForeignKey("IdOdontologo")]
        public Odontologo? Odontologo { get; set; }

        [JsonIgnore]
        [ForeignKey("IdConsultorio")]
        public Consultorio? Consultorio { get; set; }

        //relaciones detallecita
        [JsonIgnore]
        public List<DetalleCita> DetallesCita { get; set; } = new List<DetalleCita>();

        // Navegación cita
        [JsonIgnore]
        public virtual Factura? Factura { get; set; }

        // relacion con recetas
        [JsonIgnore]
        public List<Receta>? Recetas { get; set; } = new List<Receta>();
    }
}