namespace VentasDale.Domain.Dto
{
    public class ProductoResponseDto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal ValorUnitario { get; set; }
    }
}
