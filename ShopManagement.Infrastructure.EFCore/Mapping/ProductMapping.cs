

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(256);
            builder.Property(x => x.Code).HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Picture).HasMaxLength(500);
            builder.Property(x => x.PictureAlt).HasMaxLength(256);
            builder.Property(x => x.ShortDescription).HasMaxLength(500);
            builder.Property(x => x.PictureTitle).HasMaxLength(256);
            builder.Property(x => x.KeyWords).HasMaxLength(256);
            builder.Property(x => x.MetaDescription).HasMaxLength(256);
            builder.Property(x => x.Slug).HasMaxLength(300);
        }
    }
}
