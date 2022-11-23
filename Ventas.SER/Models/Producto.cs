using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Ventas.SER.Context;

namespace Ventas.SER.Models
{
    [Index(nameof(SKU), IsUnique = true)]
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El codigo unico es requerido")]
        public string SKU { get; set; }

        [Required(ErrorMessage = "La descripcion es requerida")]
        [MaxLength(255, ErrorMessage = "Ha ingresado el numero maximo de caracteres")]
        public string Descripcion { get; set; }


        [Required(ErrorMessage = "El precio es requerido")]
        public float Precio { get; set; }

        public DateTime FechaHoraCreacion { get; set; } = DateTime.Now;
    }
}
