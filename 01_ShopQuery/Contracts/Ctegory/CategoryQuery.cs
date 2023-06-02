using ShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ShopQuery.Contracts.Ctegory
{
    public class CategoryQuery : ICategoryQuery
    {
        private readonly ShopContext _ctx;

        public CategoryQuery(ShopContext ctx)
        {
            _ctx = ctx;
        }
        public List<CategoryQueryModel> GetCategories()
        {
            return _ctx.Categories.Where(c=>c.IsDeleted==false).Select(c => new CategoryQueryModel
            {
                Id=c.Id,
                Name = c.Name,
                Picture=c.Picture,
                PictureAlt=c.PictureAlt,
                PictureTitle=c.PictureTitle,
                Slug=c.Slug
            }).ToList();
        }
    }
}
