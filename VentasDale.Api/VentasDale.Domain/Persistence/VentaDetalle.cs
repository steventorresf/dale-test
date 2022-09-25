using System.ComponentModel.DataAnnotations;

namespace VentasDale.Domain.Persistence
{
    public class VentaDetalle
    {
        [Key]
        public int VentaDetalleId { get; set; }

        [Required]
        public int VentaId { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [Required]
        public decimal Cantidad { get; set; }

        [Required]
        public decimal ValorUnitario { get; set; }

        public virtual Venta? Venta { get; set; }
        public virtual Producto? Producto { get; set; }
    }
}
