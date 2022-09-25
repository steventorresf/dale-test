using Microsoft.EntityFrameworkCore;
using VentasDale.Domain.Persistence;
using VentasDale.Persistence.Interfaces;

namespace VentasDale.Persistence.Implementations
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DbApiContext _context;

        public ClienteRepository(DbApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            try
            {
                IEnumerable<Cliente> lista = await _context.Cliente
                    .Include(v => v.Ventas).ThenInclude(vd => vd.VentasDetalle)
                    .ToListAsync();
                return lista;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<Cliente?> GetById(int id)
        {
            try
            {
                Cliente? cliente = await _context.Cliente
                    .Include(v => v.Ventas).ThenInclude(vd => vd.VentasDetalle)
                    .FirstOrDefaultAsync(c => c.ClienteId == id);
                return cliente;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Cliente?> GetByCedula(string cedula)
        {
            try
            {
                Cliente? cliente = await _context.Cliente
                    .Include(v => v.Ventas).ThenInclude(vd => vd.VentasDetalle)
                    .FirstOrDefaultAsync(c => c.Cedula.Equals(cedula));
                return cliente;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Cliente> Save(Cliente cliente)
        {
            try
            {
                await _context.Set<Cliente>().AddAsync(cliente);
                _context.Entry(cliente).State = EntityState.Added;
                await _context.SaveChangesAsync();
                return cliente;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Cliente> Update(Cliente cliente)
        {
            try
            {
                _context.Set<Cliente>().Attach(cliente);
                _context.Entry(cliente).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return cliente;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
