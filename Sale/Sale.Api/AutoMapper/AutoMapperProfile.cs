using AutoMapper;
using Sale.Shared.Modelo.DTO;
using Sale.Shared.Modelo.Entidades;

namespace Sale.Api.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            
            CreateMap<Pais, PaisDTO>().ReverseMap();
            CreateMap<Pais, PaisDropDTO>().ReverseMap();
            
        }
    }
}
