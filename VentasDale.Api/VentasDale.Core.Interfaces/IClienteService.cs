using VentasDale.Domain.Dto;

namespace VentasDale.Core.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteResponseDto>> GetAll();
        Task<ClienteResponseDto> GetById(int id);
        Task<ClienteResponseDto> GetByCedula(string cedula);
        Task<ClienteRequestDto> Save(ClienteRequestDto request);
        Task<ClienteRequestDto> Update(ClienteRequestDto request);
    }
}
