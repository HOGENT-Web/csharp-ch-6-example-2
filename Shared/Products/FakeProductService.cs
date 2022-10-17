using Bogus;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Shared.Products;

public class FakeProductService : IProductService
{
    private readonly List<ProductDto.Index> _products = new();
    public FakeProductService()
    {
        var productIds = 0;
        var productFaker = new Faker<ProductDto.Index>("nl")
        .UseSeed(1337) // Always return the same products
        .RuleFor(x => x.Id, _ => ++productIds)
        .RuleFor(x => x.Name, f => f.Commerce.ProductName())
        .RuleFor(x => x.Price, f => f.Random.Decimal(0, 250));
        _products = productFaker.Generate(25);
    }

    public Task<IEnumerable<ProductDto.Index>> GetIndexAsync()
    {
        return Task.FromResult(_products.AsEnumerable());
    }
}
