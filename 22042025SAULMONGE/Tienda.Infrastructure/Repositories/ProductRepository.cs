using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Tienda.Domain.Entities;
using Tienda.Infrastructure.Data;

namespace Tienda.Infrastructure.Repositories
{
    public class ProductRepository : IProductoRepositorio
    {
        private readonly AppDbContext _ctx;
        public ProductRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task AddAsync(Producto product, CancellationToken ct = default)
            => await _ctx.Products.AddAsync(product, ct);

        public async Task DeleteAsync(Producto product, CancellationToken ct = default)
        {
            _ctx.Products.Remove(product);
            await _ctx.SaveChangesAsync(ct);
        }

        public async Task<IReadOnlyList<Producto>> GetAllAsync(CancellationToken ct = default)
            => await _ctx.Products.AsNoTracking().ToListAsync(ct);

        public async Task<Producto?> GetByIdAsync(Guid id, CancellationToken ct = default)
            => await _ctx.Products.FindAsync(new object[] { id }, ct);

        public async Task UpdateAsync(Producto product, CancellationToken ct = default)
        {
            _ctx.Products.Update(product);
            await _ctx.SaveChangesAsync(ct);
        }
    }
}
