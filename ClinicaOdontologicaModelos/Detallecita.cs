using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClinicaOdontologicaModelos
{
    [Table("detallescita")]
    public class DetalleCita
    {
        [Key]
        [Column("id_detalle_cita")]
        public int IdDetalleCita { get; set; }

        [Column("costo_aplicado", TypeName = "numeric(10,2)")]
        public decimal costoAplicado { get; set; }

        [Column("observaciones")]
        [MaxLength(200)]
        public string observaciones { get; set; }

        [ForeignKey("cita")]
        [Column("id_cita")]
        public int IdCita { get; set; }
        [JsonIgnore]

        public Cita? cita { get; set; }

        [ForeignKey("tratamiento")]
        [Column("id_tratamiento")]

        public int IdTratamiento { get; set; }
        [JsonIgnore]

        public Tratamiento? tratamiento { get; set; }
    }
}