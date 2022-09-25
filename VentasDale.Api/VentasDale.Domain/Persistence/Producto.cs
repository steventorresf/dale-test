using System.ComponentModel.DataAnnotations;

namespace VentasDale.Domain.Persistence
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public decimal ValorUnitario { get; set; }

        public virtual ICollection<VentaDetalle> VentasDetalle { get; set; } = new List<VentaDetalle>();
    }
}
