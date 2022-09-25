using VentasDale.Domain.Dto;
using VentasDale.Domain.Persistence;

namespace VentasDale.Core.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<ProductoResponseDto>> GetAll();
        Task<ProductoResponseDto> GetById(int id);
        Task<ProductoRequestDto> Save(ProductoRequestDto request);
        Task<ProductoRequestDto> Update(ProductoRequestDto request);
    }
}
