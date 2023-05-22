using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    using Data.Models;

    using Microsoft.EntityFrameworkCore;

    public class ImageConfiguration : IEntityTypeConfiguration<Images>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Images> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.ImageSource).HasColumnType("nvarchar(max)");
            builder.HasOne(p => p.ShoeDetails).WithMany(p => p.Images).HasForeignKey(p => p.IdShoeDetail);
        }
    }
}
