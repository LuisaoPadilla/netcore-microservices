using AutoMapper;
using LibreriaEcommerce.Api.Libro.Data.Context;
using LibreriaEcommerce.Api.Libro.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibreriaEcommerce.Api.Libro.Application
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<LibroDTO>> 
        {

        }

        public class Manejador : IRequestHandler<Ejecuta, List<LibroDTO>>
        {
            private readonly AppDbContext dbContext;
            private readonly IMapper mapper;

            public Manejador(AppDbContext dbContext, IMapper mapper)
            {
                this.dbContext = dbContext;
                this.mapper = mapper;
            }

            public async Task<List<LibroDTO>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var list = await dbContext.Libros.ToListAsync();
                return mapper.Map<List<LibroDTO>>(list);
            }
        }
    }
}
