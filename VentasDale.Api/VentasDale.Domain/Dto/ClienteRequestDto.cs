using System.ComponentModel.DataAnnotations;

namespace VentasDale.Domain.Dto
{
    public class ClienteRequestDto
    {
        [Required]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(20)]
        public string Cedula { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Telefono { get; set; }
    }
}
