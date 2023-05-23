namespace Data.Configurations;

using Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetails>
{
    public void Configure(EntityTypeBuilder<CartDetails> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasOne(p => p.ShoeDetails).WithMany(p => p.CartDetails).HasForeignKey(p => p.IdShoeDetail);
        builder.HasOne(p => p.Carts).WithMany(p => p.CartDetails).HasForeignKey(p => p.IdUser);
    }
}