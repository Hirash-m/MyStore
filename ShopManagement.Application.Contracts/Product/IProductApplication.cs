using _0_FrameWork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Product
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct command);
        OperationResult Edit(EditProduct command);
        EditProduct GetDetails(int id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);

        OperationResult InStock(int id);
        OperationResult InNotStock(int id);
    }
}
