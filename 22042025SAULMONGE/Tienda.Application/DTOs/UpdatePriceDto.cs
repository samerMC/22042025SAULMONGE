using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Application.DTOs
{
    public record UpdatePriceDto(Guid Id, decimal NewPrice);
}
