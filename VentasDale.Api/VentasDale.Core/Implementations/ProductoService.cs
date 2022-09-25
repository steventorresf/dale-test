using VentasDale.Core.Interfaces;
using VentasDale.Domain.Dto;
using VentasDale.Domain.Persistence;
using VentasDale.Persistence.Interfaces;

namespace VentasDale.Core.Implementations
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductoResponseDto>> GetAll()
        {
            try
            {
                IList<ProductoResponseDto> listado = new List<ProductoResponseDto>();

                var lista = await _repository.GetAll();
                foreach (var p in lista)
                {
                    listado.Add(new ProductoResponseDto
                    {
                        ProductoId = p.ProductoId,
                        Nombre = p.Nombre,
                        ValorUnitario = p.ValorUnitario
                    });
                }

                return listado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProductoResponseDto> GetById(int id)
        {
            try
            {
                Producto? producto = await _repository.GetById(id);
                ProductoResponseDto productoDto = new ProductoResponseDto
                {
                    ProductoId = producto.ProductoId,
                    Nombre = producto.Nombre,
                    ValorUnitario = producto.ValorUnitario
                };

                return productoDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProductoRequestDto> Save(ProductoRequestDto request)
        {
            try
            {
                Producto producto = new()
                {
                    ProductoId = request.ProductoId,
                    Nombre = request.Nombre,
                    ValorUnitario = request.ValorUnitario
                };

                producto = await _repository.Save(producto);

                request = new()
                {
                    ProductoId = producto.ProductoId,
                    Nombre = producto.Nombre,
                    ValorUnitario = producto.ValorUnitario
                };

                return request;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProductoRequestDto> Update(ProductoRequestDto request)
        {
            try
            {
                Producto producto = new()
                {
                    ProductoId = request.ProductoId,
                    Nombre = request.Nombre,
                    ValorUnitario = request.ValorUnitario
                };

                producto = await _repository.Update(producto);

                request = new()
                {
                    ProductoId = producto.ProductoId,
                    Nombre = producto.Nombre,
                    ValorUnitario = producto.ValorUnitario
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
