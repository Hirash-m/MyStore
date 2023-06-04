using _0_FrameWork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public interface ICustomerDiscountRepository : IRepository<DiscountManagement.Domain.CustomerDiscountAgg.CustomerDiscount,int>
    {
        
        public List<CustomerDiscountViewModel> CustomerDiscounts(CustomerDiscountSearch command);
        public CustomerDiscountEdit GetDetails(int id);
    }
}
