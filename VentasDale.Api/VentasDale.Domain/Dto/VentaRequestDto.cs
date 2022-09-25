using VentasDale.Domain.Persistence;

namespace VentasDale.Domain.Dto
{
    public class VentaRequestDto
    {
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public ICollection<VentaDetalleRequestDto> VentasDetalle { get; set; } = new List<VentaDetalleRequestDto>();
    }

    public class VentaDetalleRequestDto
    {
        public int VentaDetalleId { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
