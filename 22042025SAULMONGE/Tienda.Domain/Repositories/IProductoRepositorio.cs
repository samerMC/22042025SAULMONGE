using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Domain.Entities;

namespace Tienda.Domain.Repositories
{
    public interface IProductoRepositorio
    {
        Task<IReadOnlyList<Producto>> GetAllAsync(CancellationToken ct = default);
        Task<Producto?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task AddAsync(Producto product, CancellationToken ct = default);
        Task UpdateAsync(Producto product, CancellationToken ct = default);
        Task DeleteAsync(Producto product, CancellationToken ct = default);
    }
}
