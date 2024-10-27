using System.ComponentModel.DataAnnotations;

namespace MoviesAPI_EFCore7.DTO_s
{
    public class GeneroCreacionDTO
    {
        [Required]
        [StringLength(maximumLength: 150)]
        public string Nombre { get; set; } = null!;
    }
}
