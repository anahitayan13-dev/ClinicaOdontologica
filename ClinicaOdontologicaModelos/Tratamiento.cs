using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Text.Json.Serialization;

namespace ClinicaOdontologicaModelos
{
    // 1 MAPEO
    [Table("Tratamientos")]
    public class Tratamiento
    {
        [Key]
        [Column("id_Tratamiento")]
        public int IdTratamiento { get; set;}

        
        [Column("nombre_tratamiento")]
        [MaxLength(50)]
        [Required]
        public string nombre { get; set; }

      

        [Column(TypeName = "numeric(10,2)")]
        [Required]
        public decimal costoBase { get; set; }

        [Column("duracion_estimada_minutos")]
        [Required]
        public TimeOnly duracioonEstimadaMinutos { get; set; }

        // relación con detalles de cita
        [JsonIgnore]
        public List<DetalleCita> DetallesCita { get; set; } = new List<DetalleCita>();



    }
}
