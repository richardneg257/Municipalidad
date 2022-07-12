using AutoMapper;
using Municipalidad.Abastecimiento.WebAPI.Dtos;
using Municipalidad.Abastecimiento.WebAPI.Models;

namespace Municipalidad.Abastecimiento.WebAPI.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Estado, GetEstadoDto>();
            CreateMap<Producto, GetProductoDto>();
            CreateMap<Area, GetAreaDto>();
        }
    }
}
