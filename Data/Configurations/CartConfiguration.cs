namespace Data.Configurations;

using Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CartConfiguration : IEntityTypeConfiguration<Carts>
{
    public void Configure(EntityTypeBuilder<Carts> builder)
    {
        builder.HasKey(p => p.IdUser);
        builder.HasOne(p => p.Users).WithOne(p => p.Carts).HasForeignKey<Carts>(p => p.IdUser);
    }
}