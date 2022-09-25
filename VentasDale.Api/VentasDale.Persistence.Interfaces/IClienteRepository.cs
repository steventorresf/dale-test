using VentasDale.Domain.Persistence;

namespace VentasDale.Persistence.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente?> GetById(int id);
        Task<Cliente?> GetByCedula(string cedula);
        Task<Cliente> Save(Cliente cliente);
        Task<Cliente> Update(Cliente cliente);
    }
}
