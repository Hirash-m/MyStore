using System;

using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace ShopManagement.Domain.CategoryAgg
{
    public interface ICategoryRepository
    {
        void Create(Category entity);
        Category GetCategory(int id);

        List<Category> GetCategories();
        bool Exist(Expression<Func<Category, bool>> expression);
        void SaveChanges();

    }
}
