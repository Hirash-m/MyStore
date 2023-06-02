using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class SlideMapping : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.Property(x => x.Heading).HasMaxLength(255);
            builder.Property(x => x.Title).HasMaxLength(255);
            builder.Property(x => x.BtnText).HasMaxLength(50);
            builder.Property(x => x.Text).HasMaxLength(1000);
            builder.Property(x => x.Picture).HasMaxLength(1000);
            builder.Property(x => x.Link).HasMaxLength(1000);
            builder.Property(x => x.PictureAlt).HasMaxLength(500);
            builder.Property(x => x.PictureTitle).HasMaxLength(500);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

        }
    }
}
