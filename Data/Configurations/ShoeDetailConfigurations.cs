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

    public class ShoeDetailConfigurations : IEntityTypeConfiguration<ShoeDetails>
    {
        public void Configure(EntityTypeBuilder<ShoeDetails> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name).HasColumnType("nvarchar(100)");
            builder.Property(p => p.CostPrice).HasColumnType("int");
            builder.Property(p => p.SellPrice).HasColumnType("int");
            builder.Property(p => p.AvailableQuantity).HasColumnType("int");
            builder.Property(p => p.Status).HasColumnType("int");
            builder.HasOne(p => p.Supplier).WithMany(p => p.ShoeDetails).HasForeignKey(p => p.IdSupplier);
            builder.HasOne(p => p.Categories).WithMany(p => p.ShoeDetails).HasForeignKey(p => p.IdCategory);
            builder.HasOne(p => p.Brands).WithMany(p => p.ShoeDetails).HasForeignKey(p => p.IdBrand);
            builder.HasOne(p => p.Sales).WithMany(p => p.ShoeDetails).HasForeignKey(p => p.IdSale);
        }
    }
}
