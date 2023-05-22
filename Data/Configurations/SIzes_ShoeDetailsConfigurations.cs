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

    public class SIzes_ShoeDetailsConfigurations : IEntityTypeConfiguration<Sizes_ShoeDetails>
    {
        public void Configure(EntityTypeBuilder<Sizes_ShoeDetails> builder)
        {
            //viet config cho bang Sizes_ShoeDetails o day
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.ShoeDetails).WithMany(p => p.Sizes_ShoeDetails).HasForeignKey(p => p.IdShoeDetails);
            builder.HasOne(p => p.Sizes).WithMany(p => p.Sizes_ShoeDetails).HasForeignKey(p => p.IdSize);
        }
    }
}
