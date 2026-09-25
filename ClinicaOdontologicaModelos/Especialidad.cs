using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologicaModelos
{
    [Table("Especialidades")]
    public class Especialidad
    {
        [Key]
        [Column("id_especialidad")]
        public int IdEspecialidad { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("nombre_especialidad")]
        public string NombreEspecialidad { get; set; }

        [MaxLength(200)]
        [Column("descripcion")]
        public string? Descripcion { get; set; }

        // relación con odontólogos
        public List<Odontologo> Odontologos { get; set; } = new List<Odontologo>();
    }
}
