namespace Data.Configurations;

using Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class Color_ShoeDetailConfiguration : IEntityTypeConfiguration<Color_ShoeDetails>
{
    public void Configure(EntityTypeBuilder<Color_ShoeDetails> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(p => p.Colors).WithMany(p => p.Color_ShoeDetails).HasForeignKey(p => p.IdColor);
        builder.HasOne(p => p.ShoeDetails).WithMany(p => p.Color_ShoeDetails).HasForeignKey(p => p.IdShoeDetail);
    }
}