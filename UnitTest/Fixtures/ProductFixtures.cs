using Entity.Dto.Product;
using System.Collections.Generic;

namespace UnitTest.Fixtures;
/// <summary>
/// Test sınıfı için kullanacağımız Mock ürün verileri static classı
/// </summary>
public static class ProductFixtures
{
    public static List<ProductListDto> GetProductList() => new()
    {
        new ProductListDto
        {
            Id = 1,
            Name = "Buzdolabı",
            Description = "No Frost",
            Stock = 500
        },
        new ProductListDto
        {
            Id = 2,
            Name = "Bulaşık Makinesi",
            Description = "Metal Taban",
            Stock = 200
        }
    };
}
