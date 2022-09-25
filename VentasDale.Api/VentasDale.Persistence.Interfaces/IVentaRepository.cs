using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasDale.Domain.Persistence;

namespace VentasDale.Persistence.Interfaces
{
    public interface IVentaRepository
    {
        Task<IEnumerable<Venta>> GetAll();
        Task<Venta> GetById(int id);
        Task<Venta> Save(Venta venta);
    }
}
