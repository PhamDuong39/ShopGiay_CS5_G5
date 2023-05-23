namespace Data.Configurations;

using Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<Users>
{
    public void Configure(EntityTypeBuilder<Users> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(p => p.Roles).WithMany(p => p.Users).HasForeignKey(p => p.IdRole);
        builder.HasOne(p => p.Carts).WithOne(p => p.Users).HasForeignKey<Carts>(p => p.IdUser);
    }
}