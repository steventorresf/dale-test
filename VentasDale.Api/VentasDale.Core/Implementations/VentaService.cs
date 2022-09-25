using VentasDale.Core.Interfaces;
using VentasDale.Domain.Dto;
using VentasDale.Domain.Persistence;
using VentasDale.Persistence.Interfaces;

namespace VentasDale.Core.Implementations
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository _repository;

        public VentaService(IVentaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<VentaResponseDto>> GetAll()
        {
            try
            {
                IList<VentaResponseDto> listado = new List<VentaResponseDto>();

                var lista = await _repository.GetAll();
                foreach (var v in lista)
                {
                    IList<VentaDetalleResponseDto> listDetalle = new List<VentaDetalleResponseDto>();
                    foreach(var vd in v.VentasDetalle)
                    {
                        listDetalle.Add(new VentaDetalleResponseDto
                        {
                            VentaDetalleId = vd.VentaDetalleId,
                            ProductoId = vd.ProductoId,
                            NombreProducto = vd.Producto.Nombre,
                            Cantidad = vd.Cantidad,
                            ValorUnitario = vd.ValorUnitario,
                            ValorTotal = vd.Cantidad * vd.ValorUnitario
                        });
                    }

                    listado.Add(new VentaResponseDto
                    {
                        VentaId = v.VentaId,
                        ClienteId = v.ClienteId,
                        Cedula = v.Cliente?.Cedula,
                        Nombre = v.Cliente?.Nombre,
                        Apellido = v.Cliente.Apellido,
                        Telefono = v.Cliente.Telefono,
                        FechaVenta = v.Fecha,
                        VentasDetalle = listDetalle,
                        Total = listDetalle.Sum(vd => vd.ValorTotal)
                    });
                }

                return listado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<VentaResponseDto> GetById(int id)
        {
            try
            {
                Venta venta = await _repository.GetById(id);

                IList<VentaDetalleResponseDto> listDetalle = new List<VentaDetalleResponseDto>();
                foreach (var vd in venta.VentasDetalle)
                {
                    listDetalle.Add(new VentaDetalleResponseDto
                    {
                        VentaDetalleId = vd.VentaDetalleId,
                        ProductoId = vd.ProductoId,
                        NombreProducto = vd.Producto.Nombre,
                        Cantidad = vd.Cantidad,
                        ValorUnitario = vd.ValorUnitario,
                        ValorTotal = vd.Cantidad * vd.ValorUnitario
                    });
                }

                VentaResponseDto ventaResponse = new()
                {
                    VentaId = venta.VentaId,
                    ClienteId = venta.ClienteId,
                    Cedula = venta.Cliente.Cedula,
                    Nombre = venta.Cliente?.Nombre,
                    Apellido = venta.Cliente?.Apellido,
                    Telefono = venta.Cliente.Telefono,
                    FechaVenta = venta.Fecha,
                    VentasDetalle = listDetalle,
                    Total = listDetalle.Sum(vd => vd.ValorTotal)
                };

                return ventaResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<VentaRequestDto> Save(VentaRequestDto request)
        {
            try
            {
                IList<VentaDetalle> listDetalle = new List<VentaDetalle>();
                foreach(var vd in request.VentasDetalle)
                {
                    listDetalle.Add(new VentaDetalle()
                    {
                        VentaDetalleId = 0,
                        VentaId = 0,
                        ProductoId = vd.ProductoId,
                        Cantidad = vd.Cantidad,
                        ValorUnitario = vd.ValorUnitario,
                        Venta = null,
                        Producto = null
                    });
                }

                Venta venta = new()
                {
                    VentaId = 0,
                    ClienteId = request.ClienteId,
                    Fecha = request.Fecha,
                    VentasDetalle = listDetalle
                };

                venta = await _repository.Save(venta);

                request = new()
                {
                    VentaId = venta.VentaId,
                    ClienteId = venta.ClienteId,
                    Fecha = venta.Fecha,
                    VentasDetalle = venta.VentasDetalle.Select(x => new VentaDetalleRequestDto
                    {
                        VentaDetalleId = x.VentaDetalleId,
                        VentaId = x.VentaId,
                        ProductoId = x.ProductoId,
                        Cantidad = x.Cantidad,
                        ValorUnitario = x.ValorUnitario
                    }).ToList()
                };

                return request;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
