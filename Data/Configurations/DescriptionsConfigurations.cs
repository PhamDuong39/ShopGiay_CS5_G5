using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    using Data.Models;

    using Microsoft.EntityFrameworkCore;

    public class DescriptionsConfigurations : IEntityTypeConfiguration<Descriptions>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Descriptions> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Note1).HasColumnType("nvarchar(max)");
            builder.Property(p => p.Note2).HasColumnType("nvarchar(max)");
            builder.Property(p => p.Note3).HasColumnType("nvarchar(max)");
            builder.HasOne(p => p.ShoeDetails).WithMany(p => p.Descriptions).HasForeignKey(p => p.IdShoeDetail);
        }
    }
}
