using System.ComponentModel.DataAnnotations;

namespace VentasDale.Domain.Persistence
{
    public class Venta
    {
        [Key]
        public int VentaId { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        public virtual Cliente? Cliente { get; set; }
        public virtual ICollection<VentaDetalle> VentasDetalle { get; set; } = new List<VentaDetalle>();
    }
}
