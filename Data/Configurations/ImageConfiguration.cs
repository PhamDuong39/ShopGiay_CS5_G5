namespace Data.Configurations;

using Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ImageConfiguration : IEntityTypeConfiguration<Images>
{
    public void Configure(EntityTypeBuilder<Images> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasOne(p => p.ShoeDetails).WithMany(p => p.Images).HasForeignKey(p => p.IdShoeDetail);
    }
}