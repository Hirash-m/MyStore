using DiscountManagement.Application.Contract.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ServiceHost.Areas.Administration.Pages.Discount.CustomerDiscount
{
    public class IndexModel : PageModel
    {
        public CustomerDiscountSearch Search;
        public List<CustomerDiscountViewModel> DiscountViewModels;
        public CustomerDiscountEdit discountEdit;


        private readonly ICustomerDiscountApplication _discount;

        public IndexModel(ICustomerDiscountApplication discount)
        {
            _discount = discount;
        }



        public void OnGet(CustomerDiscountSearch search)
        {

            DiscountViewModels=_discount.CustomerDiscountViewModels(search);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CustomerDiscountCreate());
        }
        public JsonResult OnPostCreate(CustomerDiscountCreate command)
        {
          var result =  _discount.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(int id)
        {
            discountEdit = _discount.GetDetails(id);
            return Partial("./Edit", discountEdit);
        }
        public JsonResult OnPostEdit(CustomerDiscountEdit command)
        {
            var result = _discount.Edit(command) ;
            return new JsonResult(result);
        }

    }
}
