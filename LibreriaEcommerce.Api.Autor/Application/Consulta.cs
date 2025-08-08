using AutoMapper;
using LibreriaEcommerce.Api.Autor.Data.Context;
using LibreriaEcommerce.Api.Autor.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibreriaEcommerce.Api.Autor.Application
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<AutorDTO>>
        {

        }

        public class Manejador : IRequestHandler<Ejecuta, List<AutorDTO>>
        {
            private readonly AppDbContext dbContext;
            private readonly IMapper mapper;

            public Manejador(AppDbContext dbContext, IMapper mapper)
            {
                this.dbContext = dbContext;
                this.mapper = mapper;
            }

            public async Task<List<AutorDTO>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var autores = await dbContext.Autores.ToListAsync();
                return mapper.Map<List<AutorDTO>>(autores);
            }
        }
    }
}
