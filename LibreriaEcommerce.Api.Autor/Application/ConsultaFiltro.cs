using AutoMapper;
using LibreriaEcommerce.Api.Autor.Data.Context;
using LibreriaEcommerce.Api.Autor.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibreriaEcommerce.Api.Autor.Application
{
    public class ConsultaFiltro
    {
        public class AutorUnico : IRequest<AutorDTO>
        {
            public int AutorId { get; set; }
        }

        public class Manejador : IRequestHandler<AutorUnico, AutorDTO>
        {
            private readonly AppDbContext dbContext;
            private readonly IMapper mapper;

            public Manejador(AppDbContext dbContext, IMapper mapper)
            {
                this.dbContext = dbContext;
                this.mapper = mapper;
            }

            public async Task<AutorDTO> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                var autor = await dbContext.Autores.FirstOrDefaultAsync(x => x.AutorId == request.AutorId);
                return mapper.Map<AutorDTO>(autor);
            }
        }
    }

    

}
