using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("IdPaciente")]
        public Paciente Paciente { get; set; }

        [ForeignKey("IdOdontologo")]
        public Odontologo Odontologo { get; set; }

        [ForeignKey("IdConsultorio")]
        public Consultorio Consultorio { get; set; }


        //relaciones detallecita
        public List<DetalleCita> DetallesCita { get; set; } = new List<DetalleCita>();

        // Navegación cita
        public virtual Factura Factura { get; set; }

        // relacion con recetas
        public List<Receta>? Recetas { get; set; } = new List<Receta>();
    }

}