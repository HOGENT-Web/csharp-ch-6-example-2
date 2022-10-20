using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Shared.Products;

public interface IProductService
{
    Task<IEnumerable<ProductDto.Index>> GetIndexAsync();
    Task<ProductDto.Detail> GetDetailAsync(int productId);
}
