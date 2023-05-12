using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Category;

namespace ServiceHost.Areas.Administration.Pages.Shop.Category
{
    public class IndexModel : PageModel
    {
        public CategorySearchModel SearchModel;
        public List<CategoryViewModel> CategoryView;
        private readonly ICategoryApplication _categoryApplication;

        public IndexModel(ICategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }


        public void OnGet(CategorySearchModel searchModel)

        {

            CategoryView = _categoryApplication.Search(searchModel);


        }

        public JsonResult OnPostCreate(CreateCategory createCategory)

        {

           var result = _categoryApplication.Create(createCategory);

            return new JsonResult(result);


        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateCategory());
        }

        public IActionResult OnGetEdit(int id)
        {
           var category = _categoryApplication.GetCategory(id);
            return Partial("./Edit",category);
        }


        public JsonResult OnPostEdit(EditCategory editCategory)

        {

          var result=  _categoryApplication.Edit(editCategory);

            return new JsonResult(result);


        }
    }
}
