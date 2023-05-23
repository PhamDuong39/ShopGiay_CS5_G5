namespace Data.Configurations;

using Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DescConfiguration : IEntityTypeConfiguration<Descriptions>
{
    public void Configure(EntityTypeBuilder<Descriptions> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasOne(p => p.ShoeDetails).WithMany(p => p.Descriptions).HasForeignKey(p => p.IdShoeDetail);
    }
}