using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellationToken)
    {
        using var session = store.LightweightSession();
        if (await session.Query<Product>().AnyAsync())
            return;

        // Marten UPSERT will cater for existing records
        session.Store<Product>(GetPreconfiguredProducts());
        await session.SaveChangesAsync();
    }



    private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>()
    {
        new Product
        {
            Id = Guid.Parse("b0e1f8c2-3c4d-4e5f-9a6b-7c8d9e0f1a2b"),
            Name = "IPhone X",
            Category = new List<string> { "Smart Phone" },
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
            ImageFile = "product-1.png",
            Price = 950.00M
        },
        new Product
        {
            Id = Guid.Parse("c1d2e3f4-5a6b-7c8d-9e0f-1a2b3c4d5e6f"),
            Name = "Samsung 10",
            Category = new List<string> { "Smart Phone" },
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
            ImageFile = "product-2.png",
            Price = 840.00M
        },
        new Product
        {
            Id = Guid.Parse("c2d2e3f4-5a6b-7c8d-9e0f-1a2b3c4d5e6f"),
            Name = "Huawei Plus",
            Category = new List<string> { "White Appliances" },
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
            ImageFile = "product-3.png",
            Price = 650.00M
        }
    };
}



