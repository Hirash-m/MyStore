using _0_FrameWork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public interface IProductPictureApplication
    {
        OperationResult Create(CreateProductPicture command);
        OperationResult Edit(EditProductPicture command);
        OperationResult Delete(int id);
        OperationResult Restore(int id);
        EditProductPicture GetDetails(int id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel command);

    }
}
