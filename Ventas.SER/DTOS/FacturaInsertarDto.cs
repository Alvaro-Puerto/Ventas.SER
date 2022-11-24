using AutoMapper.Configuration.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ventas.SER.Models;

namespace Ventas.SER.DTOS
{
    public class FacturaInsertarDto
    {
        public DateTime Fecha { get; set; }

        public int ClienteId { get; set; }

        [Ignore]
        public ICollection<DetalleFacturaInsertarDto> FacturaDetalles { get; set; }
    }
}
