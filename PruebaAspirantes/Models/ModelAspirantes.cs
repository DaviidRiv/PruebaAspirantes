using System.ComponentModel.DataAnnotations;

namespace PruebaAspirantes.Models
{
    public class ModelAspirantes
    {
        public int Id { get; set; }
        [Required]
        public string? nombre { get; set; }
        [Required]
        public string? apellido { get; set; }
        [Required]
        [EmailAddress]
        public string? correoElectronico { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El número telefónico solo puede contener dígitos.")]
        public string? numTelefonico { get; set; }
        [Required]
        public string? lugarNacimiento { get; set; }
    }
}
