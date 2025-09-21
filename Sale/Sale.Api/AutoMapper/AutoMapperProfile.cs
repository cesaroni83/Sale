using AutoMapper;
using Sale.Shared.Modelo.DTO;
using Sale.Shared.Modelo.Entidades;

namespace Sale.Api.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Pais, PaisDTO>().ReverseMap();
            CreateMap<Pais, PaisDropDTO>().ReverseMap();
            CreateMap<Provincia, ProvinciaDTO>().ReverseMap();
            CreateMap<Provincia, ProvinciaDropDTO>().ReverseMap();
            CreateMap<Ciudad, CiudadDTO>().ReverseMap();
            CreateMap<Ciudad, CiudadDropDTO>().ReverseMap();
            CreateMap<Menu, MenuDTO>().ReverseMap();
            CreateMap<Menu, MenuDropDTO>().ReverseMap();
            CreateMap<Empresa, EmpresaDTO>().ReverseMap();
            CreateMap<Empresa, EmpresaDropDTO>().ReverseMap();
            CreateMap<Sucursal, SucursalDTO>().ReverseMap();
            CreateMap<Sucursal, SucursalDropDTO>().ReverseMap();
            CreateMap<Persona, PersonaDTO>().ReverseMap();
            CreateMap<Persona, PersonaDropDTO>().ReverseMap();
        }
    }
}
