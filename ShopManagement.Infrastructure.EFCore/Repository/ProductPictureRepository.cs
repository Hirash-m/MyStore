using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;


namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductPictureRepository : BaseRepository<ProductPicture, int>, IProductPictureRepository
    {
        private readonly ShopContext _ctx;

        public ProductPictureRepository(ShopContext context) : base(context)
        {
            _ctx = context;
        }

        public EditProductPicture GetDetails(int id)
        {
            return _ctx.ProductPictures.Select(c=> new EditProductPicture
            {
                Id=c.Id,
                Picture=c.Picture,
                PictureAlt=c.PictureAlt,
                PictureTitle=c.PictureTitle,
                ProductId=c.ProductId
            }).FirstOrDefault(c=>c.Id==id);
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel command)
        {
            var query = _ctx.ProductPictures.Include(c => c.Product).Select(c => new ProductPictureViewModel
            {
                Id = c.Id,
                Picture = c.Picture,
                Product=c.Product.Name,
                CreationDate=c.CreationDate.ToString(),
                ProductId = c.Product.Id,
                IsDeleted=c.IsDeleted

            });

            if (command.ProductId != 0)
                query = query.Where(c=>c.ProductId == command.ProductId);
            return query.ToList();
        }
    }
}
