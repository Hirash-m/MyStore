using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.CategoryAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(256);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Picture).HasMaxLength(500);
            builder.Property(x => x.PictureAlt).HasMaxLength(256);
            builder.Property(x => x.PictureTitle).HasMaxLength(256);
            builder.Property(x => x.KeyWords).HasMaxLength(256);
            builder.Property(x => x.MetaDescription).HasMaxLength(256);
            builder.Property(x => x.Slug).HasMaxLength(300);
        }
    }
}
