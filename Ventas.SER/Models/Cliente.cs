using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ventas.SER.Models
{
    [Index(nameof(Identificacion), IsUnique = true)]
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage ="El nombre es requerido")]
        [MaxLength(100, ErrorMessage ="Ha alcanzado el limite de caracteres")]
        public string Nombres { get; set; }


        [Required(ErrorMessage = "El apellido es requerido")]
        [MaxLength(100, ErrorMessage = "Ha alcanzado el limite de caracteres")]
        public string Apellidos { get; set;}


        [Required(ErrorMessage = "La identificacion es requerida")]
        [MaxLength(100, ErrorMessage = "Ha alcanzado el limite de caracteres")]
        public string Identificacion { get; set;}

        
        [MaxLength(200, ErrorMessage = "Ha alcanzado el limite de caracteres")]
        public string Direccion { get; set;}


        [MinLength(8, ErrorMessage ="Debe tener al menos 8 caracteres")]
        public string Telefono { get; set;}

        public DateTime FechaHoraCreacion { get; set;} = DateTime.Now;

        public  ICollection<Factura> Facturas { get; set;}

        public string NombresCompletos()
        {
            return $" {Nombres} {Apellidos}";
        }
    }
}
 