using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;

using System.Linq.Expressions;


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

        public List<ProductViewModel> Search(ProductSearchModel SearchModel)
        {
           
            var query = _ctx.Products.Include(c=>c.Category)
                .Select( c=>new ProductViewModel
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Picture = c.Picture,
                            UnitPrice = c.UnitPrice,
                            CategoryName = c.Category.Name
                        }
                        );

            if (!string.IsNullOrWhiteSpace(SearchModel.name))
                query = query.Where(c => c.Name.Contains(SearchModel.name));

            //if (!string.IsNullOrWhiteSpace(SearchModel.Code))
            //    query = query.Where(c => c..Contains(SearchModel.Code));

            //if (!string.IsNullOrWhiteSpace(SearchModel.CategoryId))
            //    query = query.Where(c => c.c.Contains(SearchModel.name));
        }
    }
}
