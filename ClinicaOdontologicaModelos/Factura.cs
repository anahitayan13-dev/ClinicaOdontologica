using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaOdontologicaModelos
{
    [Table("facturas")]
    public class Factura
    {
        [Key]
        [Column("id_factura")]
        public int IdFactura { get; set; }

        [Column("fecha_emision")]
        public DateTime fechaEmision { get; set; }

        [Column("subtotal", TypeName = "numeric(10,2)")]
        public decimal subtotal { get; set; }

        [Column("impuestos", TypeName = "numeric(10,2)")]
        public decimal impuestos { get; set; }

        [Column("total", TypeName = "numeric(10,2)")]
        public decimal total { get; set; }

        [Column("estado_pago")]
        [MaxLength(20)]
        public string estadoPago { get; set; } = "Pendiente";

        [ForeignKey("cita")]
        [Column("id_cita")]
        public int IdCita { get; set; }
        public Cita? cita { get; set; }
    }
}