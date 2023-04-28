using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShopManagement.Domain.CategoryAgg;

namespace ShopManagem.Application.Contracts.Category
{
    public interface ICategoryApplication
    {
        void Create(CreateCategory command);
        void Edit(EditCategory command);
        ShopManagement.Domain.CategoryAgg.Category GetCategory(int id);
        List<CategoryViewModel> Search(CategorySearchModel command);
    }
}
