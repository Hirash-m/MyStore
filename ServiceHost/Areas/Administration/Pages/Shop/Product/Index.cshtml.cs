using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Category;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Areas.Administration.Pages.Shop.Product
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public ProductSearchModel SearchModel;
        public List<ProductViewModel> ProductView;
        public SelectList Categories;
        private readonly IProductApplication _productApplication;
        private readonly ICategoryApplication _categoryApplication;

        public IndexModel(IProductApplication productApplication, ICategoryApplication categoryApplication)
        {
            _productApplication = productApplication;
            _categoryApplication = categoryApplication;
        }


        public void OnGet(ProductSearchModel searchModel)

        {

            Categories = new SelectList(_categoryApplication.GetCategories(), "Id", "Name");
            ProductView = _productApplication.Search(searchModel);


        }

        public JsonResult OnPostCreate(CreateProduct createProduct)

        {

            var result = _productApplication.Create(createProduct);

            return new JsonResult(result);


        }

        public IActionResult OnGetCreate()
        {

            var command = new CreateProduct();
            command.Categories = _categoryApplication.GetCategories();
            return Partial("./Create", command);
        }

        public IActionResult OnGetEdit(int id)
        {
            var product = _productApplication.GetDetails(id);
            product.Categories = _categoryApplication.GetCategories();
            return Partial("./Edit", product);
        }


        public JsonResult OnPostEdit(EditProduct editCategory)

        {

            var result = _productApplication.Edit(editCategory);

            return new JsonResult(result);


        }

        public IActionResult OnGetNotInStock(int id)
        {
            var result = _productApplication.NotInStock(id);
            if (result.IsSucceeded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");

        }

        public IActionResult OnGetIsInStock(int id)
        {
            var result = _productApplication.InStock(id);
            if (result.IsSucceeded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");

        }
    }
}