using AutoMapper;
using Ventas.SER.DTOS;
using Ventas.SER.Models;

namespace Ventas.SER.Utils
{
    public class AutoMapperDtos : Profile
    {
        public AutoMapperDtos() { 

            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<TasaCambio, TasaCambioDto>().ReverseMap();
            CreateMap<FacturaInsertarDto, Factura>().ReverseMap();
            CreateMap<FacturaDetalle, DetalleFacturaInsertarDto>().ReverseMap();
            CreateMap<Cliente, ClienteDto>().ReverseMap();
        }
    }
}
