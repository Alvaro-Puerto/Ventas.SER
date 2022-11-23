using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ventas.SER.Models
{ 

    [Index(nameof(Fecha), IsUnique = true)]
    public class TasaCambio
    {
        [Key]
        public int TasaCambioId { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]

        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Ingrese el monto")]
        public float Monto { get; set; }

        public DateTime FechaHoraCreacion { get; set; } = DateTime.Now;

    }
}
