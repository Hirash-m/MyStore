using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;

using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductRepository : BaseRepository<Product, int>, IProductRepository
    {
        private readonly ShopContext _ctx;

        public ProductRepository(ShopContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public EditProduct GetDetails(int id)
        {

            Expression<Func<Product, EditProduct>> selector = c => new EditProduct
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                ShortDescription = c.ShortDescription,
                CategoryId = c.CategoryId,
                Code = c.Code,
                Picture = c.Picture,
                PictureAlt = c.PictureAlt,
                PictureTitle = c.PictureTitle,
                UnitPrice = c.UnitPrice,
                KeyWords = c.KeyWords,
                MetaDescription = c.MetaDescription,
                Slug = c.Slug,
                IsInStock = c.IsInStock



            };
            return _ctx.Products.Select(selector).FirstOrDefault(c => c.Id == id);

        }

        public List<ProductViewModel> GetProducts()
        {
            return _ctx.Products.Select(c => new ProductViewModel { Id=c.Id,Name=c.Name}).ToList();
        }

        public List<ProductViewModel> Search(ProductSearchModel SearchModel)
        {

            var query = _ctx.Products.Include(c => c.Category)
                .Select(c => new ProductViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Picture = c.Picture,
                    UnitPrice = c.UnitPrice,
                    CategoryId = c.CategoryId,
                    Code = c.Code,
                    CategoryName = c.Category.Name,
                    CreationDate = c.CreationDate.ToString(),
                    IsInStock=c.IsInStock
                    
                }) ;

            if (!string.IsNullOrWhiteSpace(SearchModel.name))
                query = query.Where(c => c.Name.Contains(SearchModel.name));

            if (!string.IsNullOrWhiteSpace(SearchModel.Code))
                query = query.Where(c => c.Code.Contains(SearchModel.Code));

            if (SearchModel.CategoryId != 0)
                query = query.Where(c => c.CategoryId==SearchModel.CategoryId);

            return query.ToList();
        }
        
    }
}
