using System.ComponentModel.DataAnnotations;

namespace Ventas.SER.DTOS
{
    public class ClienteDto
    {
        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Identificacion { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }
    }
}
