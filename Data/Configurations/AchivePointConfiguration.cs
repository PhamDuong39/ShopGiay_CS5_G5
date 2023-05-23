namespace Data.Configurations;

using Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AchivePointConfiguration : IEntityTypeConfiguration<AchivePoint>
{
    public void Configure(EntityTypeBuilder<AchivePoint> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(p => p.Users).WithMany(p => p.AchivePoints).HasForeignKey(p => p.IdUser);
    }
}