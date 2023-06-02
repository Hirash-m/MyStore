using ShopManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public interface IProductPictureRepository : IRepository<ShopManagement.Domain.ProductPictureAgg.ProductPicture, int>
    {
        EditProductPicture GetDetails(int id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel command);
    }
}
