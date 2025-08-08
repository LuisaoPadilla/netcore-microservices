using AutoMapper;
using LibreriaEcommerce.Api.Autor.Data.Entities;
using LibreriaEcommerce.Api.Autor.DTOs;

namespace LibreriaEcommerce.Api.Autor.Mappings
{
    public class AutoresProfiles : Profile
    {
        public AutoresProfiles()
        {
            CreateMap<AutorEntity, AutorDTO>().ForMember(x => x.NombreCompleto, config => config.MapFrom(x => $"{x.Nombre} {x.Apellido}"));
        }
    }
}
