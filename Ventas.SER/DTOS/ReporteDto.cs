namespace Ventas.SER.DTOS
{
    public class ReporteDto
    {
       
        public string NombresCompletos { get; set; } 

        public string Identificacion { get; set; }

        public int Anyo { get; set; }

        public int Mes { get; set; }

        public string SKU { get; set; }

        public string Producto { get; set; }

        public float CostoLoc { get; set;}

        public float CostoDol { get; set; }

    }
}
