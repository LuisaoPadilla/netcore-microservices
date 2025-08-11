using System.ComponentModel.DataAnnotations;

namespace LibreriaEcommerce.Api.Libro.Data.Entities
{
    public class LibroEntity
    {
        [Key]
        public Guid LibroId { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "El campo {0} debe de contener entre {2} y {1}", MinimumLength = 2)]
        public required string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public Guid AutorLibroId { get; set; }
    }
}
