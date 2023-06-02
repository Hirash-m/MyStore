using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Category;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Slide;

namespace ServiceHost.Areas.Administration.Pages.Shop.Slide
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
       
        public List<SlideViewModel> SlideViewModel;
        private readonly ISlideApplication _slideApplication;

        public IndexModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }


        public void OnGet()

        {
            SlideViewModel = _slideApplication.GetList();
        }

        public JsonResult OnPostCreate(CreateSlide createSlide)

        {

            var result = _slideApplication.Create(createSlide);

            return new JsonResult(result);


        }

        public IActionResult OnGetCreate()
        {

            var command = new CreateSlide();
            
            return Partial("./Create", command);
        }

        public IActionResult OnGetEdit(int id)
        {
            var slide = _slideApplication.GetDetails(id);
            
            return Partial("./Edit", slide);
        }


        public JsonResult OnPostEdit(EditSlide editSlide)

        {

            var result = _slideApplication.Edit(editSlide);

            return new JsonResult(result);


        }

        public IActionResult OnGetDelete(int id)
        {
            var result = _slideApplication.Delete(id);
            if (result.IsSucceeded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");

        }

        public IActionResult OnGetRestore(int id)
        {
            var result = _slideApplication.Restore(id);
            if (result.IsSucceeded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");

        }
    }
}