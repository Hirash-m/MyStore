using ShopManagement.Application.Contracts.Category;
using ShopManagement.Domain.CategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class CategoryRepository : BaseRepository<Category, int>, ICategoryRepository
    {
        private readonly ShopContext _ctx;

        public CategoryRepository(ShopContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public List<CategoryViewModel> GetCategory()
        {
            return _ctx.Categories.Select(c => new CategoryViewModel { Id = c.Id, Name = c.Name }).ToList();
        }

        public EditCategory GetDetails(int id)
        {

            return _ctx.Categories.Select(c => new EditCategory()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                KeyWords = c.KeyWords,
                MetaDescription = c.MetaDescription,
                Picture = c.Picture,
                PictureAlt = c.PictureAlt,
                PictureTitle = c.PictureTitle,
                Slug = c.Slug

            }).FirstOrDefault(c => c.Id == id);

        }


        public List<CategoryViewModel> Search(CategorySearchModel categorySearchModel)
        {
            var query = _ctx.Categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                CreationDate = c.CreationDate
            });
            if (!string.IsNullOrWhiteSpace(categorySearchModel.Name))
                query = query.Where(c => c.Name.Contains(categorySearchModel.Name));

            return query.OrderBy(c => c.Id).ToList();
        }
    }
}
