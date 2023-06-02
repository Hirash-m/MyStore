using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class ProductPictureMapping : IEntityTypeConfiguration<ProductPicture>
    {
       

        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.Property(c => c.Picture).HasMaxLength(1000);
            builder.Property(c => c.PictureTitle).HasMaxLength(500);
            builder.Property(c => c.PictureAlt).HasMaxLength(500);
            
        }
    }
}
