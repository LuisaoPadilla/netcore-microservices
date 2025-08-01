using FluentValidation;
using LibreriaEcommerce.Api.Autor.Data.Context;
using LibreriaEcommerce.Api.Autor.Data.Entities;
using MediatR;

namespace LibreriaEcommerce.Api.Autor.Application
{
    public class Nuevo
    {
        public class Ejecuta : IRequest<Unit>
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime? FechaNacimiento { get; set; }
            public Guid AutorLibroId { get; set; }
        }

        public class Validador : AbstractValidator<Ejecuta>
        {
            public Validador()
            {
                RuleFor(x => x.Nombre).NotEmpty().WithMessage("El campo Nombre es requerido");
                RuleFor(x => x.Apellido).NotEmpty().WithMessage("El campo Nombre es requerido");
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
                    var autorEntity = new AutorEntity
                    {
                         Nombre = request.Nombre,
                         Apellido = request.Apellido,
                         FechaNacimiento = request.FechaNacimiento,
                         AutorLibroId = Guid.NewGuid()
                    };
                    await dbContext.Autores.AddAsync(autorEntity);
                    var rows = await dbContext.SaveChangesAsync();
                    if (rows == 0)
                    {
                        throw new Exception($"No se pudo agregar el Autor {autorEntity.Nombre} - {autorEntity.Apellido}");
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
