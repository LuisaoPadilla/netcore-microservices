using System.ComponentModel.DataAnnotations;

namespace LibreriaEcommerce.Api.Autor.Data.Entities
{
    public class AutorEntity
    {
        [Key]
        public int AutorId { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "El campo {0} es debe de contenter entre {2} y {1} caracteres", MinimumLength = 2)]
        public required string Nombre { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "El campo {0} es debe de contenter entre {2} y {1} caracteres", MinimumLength = 2)]
        public required string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public Guid AutorLibroId { get; set; }
    }
}
