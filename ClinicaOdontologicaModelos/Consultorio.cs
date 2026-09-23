using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologicaModelos
{
    [Table("Consultorios")]
    public class Consultorio
    {
        [Key]
        [Column("id_consultorio")]
        public int IdConsultorio { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("numero_sala")]
        public string NumeroSala { get; set; }

        [Required]
        [Column("piso")]
        public int Piso { get; set; }

        [MaxLength(100)]
        [Column("equipamiento_principal")]
        public string? EquipamientoPrincipal { get; set; }
    }
}
