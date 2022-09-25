using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using VentasDale.Domain.Persistence;
using VentasDale.Persistence.Interfaces;

namespace VentasDale.Persistence.Implementations
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly DbApiContext _context;

        public ProductoRepository(DbApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetAll()
        {
            try
            {
                IEnumerable<Producto> lista = await _context.Producto.ToListAsync();
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Producto?> GetById(int id)
        {
            try
            {
                Producto? producto = await _context.Producto
                    .FirstOrDefaultAsync(c => c.ProductoId == id);
                return producto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Producto> Save(Producto producto)
        {
            try
            {
                await _context.Set<Producto>().AddAsync(producto);
                _context.Entry(producto).State = EntityState.Added;
                await _context.SaveChangesAsync();
                return producto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Producto> Update(Producto producto)
        {
            try
            {
                _context.Set<Producto>().Attach(producto);
                _context.Entry(producto).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return producto;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
