using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Category;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductPicture;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductPicture
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public ProductPictureSearchModel SearchModel;
        public List<ProductPictureViewModel> ProductPictureView;
        public SelectList Products;


        private readonly IProductPictureApplication _productPictureApplication;
        private readonly IProductApplication _productApplication;


        public IndexModel(IProductPictureApplication productPictureApplication, IProductApplication productApplication)
        {
            _productPictureApplication = productPictureApplication;
            _productApplication = productApplication;
        }


        public void OnGet(ProductPictureSearchModel searchModel)

        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");

            ProductPictureView = _productPictureApplication.Search(searchModel);
        }

        public JsonResult OnPostCreate(CreateProductPicture createProduct)

        {

            var result = _productPictureApplication.Create(createProduct);

            return new JsonResult(result);


        }

        public IActionResult OnGetCreate()
        {

            var command = new CreateProductPicture
            {
                Products = _productApplication.GetProducts()

            };
            return Partial("./Create", command);
        }

        public IActionResult OnGetEdit(int id)
        {
            var productPicture = _productPictureApplication.GetDetails(id);
            productPicture.Products = _productApplication.GetProducts(); 
            return Partial("./Edit", productPicture);
        }


        public JsonResult OnPostEdit(EditProductPicture EditProductPicture)

        {

            var result = _productPictureApplication.Edit(EditProductPicture);

            return new JsonResult(result);


        }

        public IActionResult OnGetDelete(int id)
        {
            var result = _productPictureApplication.Delete(id);
            if (result.IsSucceeded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");

        }

        public IActionResult OnGetRestore(int id)
        {
            var result = _productPictureApplication.Restore(id);
            if (result.IsSucceeded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");

        }
    }
}