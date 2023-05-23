namespace Data.Configurations;

using Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ColorsConfiguration : IEntityTypeConfiguration<Colors>
{
    public void Configure(EntityTypeBuilder<Colors> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(p => p.ColorName).HasColumnType("nvarchar(30)");

        // builder.HasOne(p => p.Id).WithMany()
    }
}