using AutoMapper;
using LibreriaEcommerce.Api.Libro.Data.Entities;
using LibreriaEcommerce.Api.Libro.DTOs;

namespace LibreriaEcommerce.Api.Libro.Mappings
{
    public class LibroProfiles : Profile
    {
        public LibroProfiles()
        {
            CreateMap<LibroEntity, LibroDTO>();
        }
    }
}
