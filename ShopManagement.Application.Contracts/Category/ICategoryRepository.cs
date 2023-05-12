using ShopManagement.Domain;



namespace ShopManagement.Application.Contracts.Category
{
    public interface ICategoryRepository : IRepository<ShopManagement.Domain.CategoryAgg.Category, int>
    {

        List<CategoryViewModel> Search(CategorySearchModel categorySearchModel);




    }
}
