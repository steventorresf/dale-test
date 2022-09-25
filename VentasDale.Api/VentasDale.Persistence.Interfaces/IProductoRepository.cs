﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasDale.Domain.Persistence;

namespace VentasDale.Persistence.Interfaces
{
    public interface IProductoRepository 
    {
        Task<IEnumerable<Producto>> GetAll();
        Task<Producto?> GetById(int id);
        Task<Producto> Save(Producto producto);
        Task<Producto> Update(Producto producto);
    }
}
