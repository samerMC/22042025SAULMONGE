using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Application.DTOs
{
    public record CreateProductDto(string Name, string Description, decimal Price, string? ImageUrl);
}
