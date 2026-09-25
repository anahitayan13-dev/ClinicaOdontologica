using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClinicaOdontologicaModelos
{
    [Table("recetas")]
    public class Receta
    {
        [Key]
        [Column("id_receta")]
        public int IdReceta { get; set; }

        [Column("fecha_emision")]
        public DateTime fechaEmision { get; set; }

        [Column("indicaciones", TypeName = "text")]
        public string indicaciones { get; set; }

        [ForeignKey("cita")]
        [Column("id_cita")]
        public int IdCita { get; set; }
        [JsonIgnore]

        public Cita? cita { get; set; }
    }
}