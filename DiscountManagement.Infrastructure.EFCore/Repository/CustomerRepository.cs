using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using ShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class CustomerRepository : BaseRepository<CustomerDiscount, int>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _ctx;
        private readonly ShopContext _sctx;

        public CustomerRepository(DiscountContext dctx, ShopContext sctx) : base(dctx)
        {
            _ctx = dctx;
            _sctx = sctx;
        }

        public List<CustomerDiscountViewModel> CustomerDiscounts(CustomerDiscountSearch command)
        {
            var products = _sctx.Products.Select(c => new { c.Id, c.Name }).ToList();
            var query = _ctx.CustomerDiscounts.Select(c => new CustomerDiscountViewModel());
            if(command.Id!= 0)
            {
                query = query.Where(c=>c.Id==command.Id);
            }
            if (!string.IsNullOrWhiteSpace(command.PrudoctName))
            {
                query = query.Where(c=>c.PrudoctName.Contains(command.PrudoctName));
            }
            return query.ToList();

        }

        public CustomerDiscountEdit GetDetails(int id)
        {
            return _ctx.CustomerDiscounts.Select(c => new CustomerDiscountEdit
            {

            }).FirstOrDefault(c=>c.Id==id);
        }
    }
}
