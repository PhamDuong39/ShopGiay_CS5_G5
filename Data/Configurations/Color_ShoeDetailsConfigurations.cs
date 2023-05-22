using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    using Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class Color_ShoeDetailsConfigurations : IEntityTypeConfiguration<Color_ShoeDetails>
    {
        public void Configure(EntityTypeBuilder<Color_ShoeDetails> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.ShoeDetails).WithMany(p => p.Color_ShoeDetails).HasForeignKey(p => p.IdShoeDetail);
            builder.HasOne(p => p.Colors).WithMany(p => p.Color_ShoeDetails).HasForeignKey(p => p.IdColor);
        }
    }
}
