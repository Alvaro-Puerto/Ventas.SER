using AutoMapper.Configuration.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Ventas.SER.Models
{
    public class Factura
    {
        [Key]
        public int FacturaId { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        public DateTime Fecha { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public ICollection<FacturaDetalle>? FacturaDetalles { get;set; }
    }
}
