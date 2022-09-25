using System;
using System.ComponentModel.DataAnnotations;

namespace VentasDale.Domain.Dto
{
    public class ProductoRequestDto
    {
        [Key]
        public int ProductoId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public decimal ValorUnitario { get; set; }
    }
}
