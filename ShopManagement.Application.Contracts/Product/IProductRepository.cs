using ShopManagement.Application.Contracts.Category;
using ShopManagement.Domain;

namespace ShopManagement.Application.Contracts.Product
{
    public interface IProductRepository : IRepository<ShopManagement.Domain.ProductAgg.Product, int>
    {
        List<ProductViewModel> Search(ProductSearchModel SearchModel);
        EditProduct GetDetails(int id);

    }
}
