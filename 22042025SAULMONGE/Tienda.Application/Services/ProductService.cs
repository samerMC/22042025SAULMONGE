using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Domain.Entities;
using Tienda.Domain.Repositories;
using Tienda.Application.DTOs;

namespace Tienda.Application.Services
{
    public class ProductService
    {
        private readonly IProductoRepositorio _repo;
        public ProductService(IProductoRepositorio repo) => _repo = repo;

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _repo.GetAllAsync();
            return products.Select(p => new ProductDto(p.Id, p.Nombre, p.Descripcion, p.Precio, p.Imagen));
        }

        public async Task<ProductDto?> GetByIdAsync(Guid id)
        {
            var p = await _repo.GetByIdAsync(id);
            return p is null ? null : new ProductDto(p.Id, p.Nombre, p.Descripcion, p.Precio, p.Imagen);
        }

        public async Task<Guid> CreateAsync(CreateProductDto dto)
        {
            var product = new Producto(dto.Name, dto.Description, dto.Price, dto.ImageUrl);
            await _repo.AddAsync(product);
            return product.Id;
        }

        public async Task UpdateAsync(UpdateProductDto dto)
        {
            var product = await _repo.GetByIdAsync(dto.Id)
                          ?? throw new KeyNotFoundException("Producto no encontrado.");
            product.ActualizarDetalle(dto.Name, dto.Description, dto.ImageUrl);
            await _repo.UpdateAsync(product);
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _repo.GetByIdAsync(id)
                          ?? throw new KeyNotFoundException("Producto no encontrado.");
            await _repo.DeleteAsync(product);
        }

        public async Task ConfigurePriceAsync(UpdatePriceDto dto)
        {
            var product = await _repo.GetByIdAsync(dto.Id)
                          ?? throw new KeyNotFoundException("Producto no encontrado.");
            product.ActualizarPrecio(dto.NewPrice);
            await _repo.UpdateAsync(product);
        }
    }
}
