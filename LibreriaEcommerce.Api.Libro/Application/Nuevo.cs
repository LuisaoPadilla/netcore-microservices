using FluentValidation;
using LibreriaEcommerce.Api.Libro.Data.Context;
using LibreriaEcommerce.Api.Libro.Data.Entities;
using MediatR;

namespace LibreriaEcommerce.Api.Libro.Application
{
    public class Nuevo
    {
        public class Ejecuta : IRequest<Unit> 
        {
            public string Titulo { get; set; }
            public DateTime? FechaPublicacion { get; set; }
            public Guid AutorLibroId { get; set; }
        }

        public class Validador : AbstractValidator<Ejecuta>
        {
            public Validador()
            {
                RuleFor(x => x.Titulo).NotEmpty().WithMessage("Campo requerido");
            }
        }

        public class Manejador : IRequestHandler<Ejecuta, Unit>
        {
            private readonly AppDbContext dbContext;

            public Manejador(AppDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                try
                {
                    var libroEntity = new LibroEntity { LibroId = Guid.NewGuid(), Titulo = request.Titulo, FechaPublicacion = request.FechaPublicacion, AutorLibroId = request.AutorLibroId };
                    await dbContext.Libros.AddAsync(libroEntity);
                    var row = await dbContext.SaveChangesAsync();
                    if (row < 1)
                    {
                        throw new Exception($"No se pudo agregar el Libro {libroEntity.Titulo}");
                    }
                    return Unit.Value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
