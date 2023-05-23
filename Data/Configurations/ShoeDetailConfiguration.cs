namespace Data.Configurations;

using Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ShoeDetailConfiguration : IEntityTypeConfiguration<ShoeDetails>
{
    public void Configure(EntityTypeBuilder<ShoeDetails> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(p => p.Sales).WithMany(p => p.ShoeDetails).HasForeignKey(p => p.IdSale);
        builder.HasOne(p => p.Brands).WithMany(p => p.ShoeDetails).HasForeignKey(p => p.IdBrand);
        builder.HasOne(p => p.Supplier).WithMany(p => p.ShoeDetails).HasForeignKey(p => p.IdSupplier);
        builder.HasOne(p => p.Categories).WithMany(p => p.ShoeDetails).HasForeignKey(p => p.IdCategory);
    }
}