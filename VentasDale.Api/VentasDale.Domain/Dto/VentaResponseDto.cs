using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasDale.Domain.Dto
{
    public class VentaResponseDto
    {
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public string Cedula { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string Apellido { get; set; } = "";
        public string Telefono { get; set; } = "";
        public DateTime FechaVenta { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<VentaDetalleResponseDto> VentasDetalle { get; set; } = new List<VentaDetalleResponseDto>();
    }

    public class VentaDetalleResponseDto
    {
        public int VentaDetalleId { get; set; }
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; } = "";
        public decimal Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
