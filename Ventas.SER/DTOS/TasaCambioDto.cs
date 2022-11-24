using System.ComponentModel.DataAnnotations;

namespace Ventas.SER.DTOS
{
    public class TasaCambioDto
    {
        public int TasaCambioId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{yyyy-MM-dd}")]
        public DateTime Fecha { get; set; }

        public float Monto { get; set; }
    }
}
