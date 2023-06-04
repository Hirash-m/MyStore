using _0_FrameWork.Application;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _customerDiscountRepository;

        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;
        }
        public OperationResult Create(CustomerDiscountCreate command)
        {
            var operation = new OperationResult();
            if (_customerDiscountRepository.Exist(c=>c.ProductId==command.ProductId))
            {return operation.Failed(ApplicationMessages.DuplicatedRecord); }
                var customerDiscount = new CustomerDiscount(command.ProductId,command.DiscountRate,
                                                        command.StartDate,command.EndDate,command.Reason);
            _customerDiscountRepository.Create(customerDiscount);
            _customerDiscountRepository.SaveChanges();
            return operation.Succeeded();
        }

        public List<CustomerDiscountViewModel> CustomerDiscountViewModels(CustomerDiscountSearch command)
        {
            return _customerDiscountRepository.CustomerDiscounts(command);
        }

        

        public OperationResult Edit(CustomerDiscountEdit command)
        {
            var operation = new OperationResult();
            var customerDiscount = _customerDiscountRepository.Get(command.Id);
            if (customerDiscount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            if (_customerDiscountRepository.Exist(c => c.Id != command.Id && c.ProductId == command.ProductId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            customerDiscount.Edit(command.ProductId, command.DiscountRate,
                                   command.StartDate, command.EndDate, command.Reason);
            _customerDiscountRepository.SaveChanges();
            return operation.Succeeded();

        }

        public CustomerDiscountEdit GetDetails(int id)
        {
            return _customerDiscountRepository.GetDetails(id);
        }
    }
}
