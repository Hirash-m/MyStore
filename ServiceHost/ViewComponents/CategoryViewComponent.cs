using _01_ShopQuery.Contracts.Ctegory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryQuery _categoryQuery;

        public CategoryViewComponent(ICategoryQuery categoryQuery)
        {
            _categoryQuery = categoryQuery;
        }
        public IViewComponentResult Invoke()
        {
            var categories = _categoryQuery.GetCategories();
            return View(categories);
        }
    }
}
