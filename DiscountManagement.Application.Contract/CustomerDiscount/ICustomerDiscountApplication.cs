using _0_FrameWork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public interface ICustomerDiscountApplication
    {
        OperationResult Create(CustomerDiscountCreate command);
        OperationResult Edit(CustomerDiscountEdit command);
        List<CustomerDiscountViewModel> CustomerDiscountViewModels(CustomerDiscountSearch command);
        CustomerDiscountEdit GetDetails(int id);
    }
}
