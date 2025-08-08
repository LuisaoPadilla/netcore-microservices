namespace LibreriaEcommerce.Api.Autor.DTOs
{
    public class AutorDTO
    {
        public string NombreCompleto { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public Guid AutorLibroId { get; set; }
    }
}
