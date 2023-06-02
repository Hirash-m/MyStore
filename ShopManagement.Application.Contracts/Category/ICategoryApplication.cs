using _0_FrameWork.Application;

namespace ShopManagement.Application.Contracts.Category
{
    public interface ICategoryApplication
    {
        OperationResult Create(CreateCategory command);
        OperationResult Edit(EditCategory command);
        EditCategory GetCategory(int id);
        List<CategoryViewModel> Search(CategorySearchModel command);
        List<CategoryViewModel> GetCategories();
        OperationResult Delete(int id);


    }
}
