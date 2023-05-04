using ShopManagement.Domain.CategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopContext _ctx;

        public CategoryRepository(ShopContext ctx)
        {
            _ctx = ctx;
        }
        public void Create(Category entity)
        {
            _ctx.Categories.Add(entity);

        }

        public bool Exist(Expression<Func<Category, bool>> expression)
        {
            return _ctx.Categories.Any(expression);
        }

        public List<Category> GetCategories()
        {
            return _ctx.Categories.ToList();

        }

        public Category GetCategory(int id)
        {
            return _ctx.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

        public E
    }
}
