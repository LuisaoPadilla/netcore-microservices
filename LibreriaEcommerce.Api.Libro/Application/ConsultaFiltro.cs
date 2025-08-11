using AutoMapper;
using LibreriaEcommerce.Api.Libro.Data.Context;
using LibreriaEcommerce.Api.Libro.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibreriaEcommerce.Api.Libro.Application
{
    public class ConsultaFiltro 
    {
        public class Ejecuta : IRequest<LibroDTO>
        {
            public Guid LibroId { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, LibroDTO>
        {
            private readonly AppDbContext dbContext;
            private readonly IMapper mapper;

            public Manejador(AppDbContext dbContext, IMapper mapper)
            {
                this.dbContext = dbContext;
                this.mapper = mapper;
            }


            public async Task<LibroDTO> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var libroEntity = await dbContext.Libros.FirstOrDefaultAsync(x => x.LibroId == request.LibroId);
                return mapper.Map<LibroDTO>(libroEntity);
                
            }
        }
    }
}
