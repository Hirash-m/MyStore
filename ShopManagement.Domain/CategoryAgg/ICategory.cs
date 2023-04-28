using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.CategoryAgg
{
    public interface ICategory
    {
        void Create(Category entity);
        Category GetCategory(int id);

        List<Category> GetCategories();
    }
}
