using Microsoft.EntityFrameworkCore;
using VentasDale.Domain.Persistence;
using VentasDale.Persistence.Interfaces;

namespace VentasDale.Persistence.Implementations
{
    public class VentaRepository : IVentaRepository
    {
        private readonly DbApiContext _context;

        public VentaRepository(DbApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Venta>> GetAll()
        {
            try
            {
                IEnumerable<Venta> lista = await _context.Venta
                    .Include(cl => cl.Cliente)
                    .Include(vd => vd.VentasDetalle).ThenInclude(p => p.Producto)
                    .ToListAsync();
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Venta> GetById(int id)
        {
            try
            {
                Venta venta = await _context.Venta
                    .Include(c => c.Cliente)
                    .Include(vd => vd.VentasDetalle).ThenInclude(p => p.Producto)
                    .FirstAsync(v => v.VentaId == id);
                return venta;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Venta> Save(Venta venta)
        {
            try
            {
                venta.Cliente = null;
                await _context.Set<Venta>().AddAsync(venta);
                _context.Entry(venta).State = EntityState.Added;
                await _context.SaveChangesAsync();
                return venta;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
