namespace VentasDale.Domain.Dto
{
    public class ClienteResponseDto
    {
        public int ClienteId { get; set; }
        public string Cedula { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public int CantidadFacturas { get; set; }
        public decimal TotalValorFacturas { get; set; }
    }
}
