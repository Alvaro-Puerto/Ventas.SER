using AutoMapper;
using Ventas.SER.DTOS;
using Ventas.SER.Models;

namespace Ventas.SER.Utils
{
    public class AutoMapperDtos : Profile
    {
        public AutoMapperDtos() { 

            CreateMap<Producto, ProductoDto>().ReverseMap();
        
        }
    }
}
