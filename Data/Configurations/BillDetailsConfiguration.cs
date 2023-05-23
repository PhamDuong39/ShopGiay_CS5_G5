namespace Data.Configurations;

using Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BillDetailsConfiguration : IEntityTypeConfiguration<BillDetails>
{
    public void Configure(EntityTypeBuilder<BillDetails> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasOne(p => p.ShoeDetails).WithMany(p => p.BillDetails).HasForeignKey(p => p.IdShoeDetail);
        builder.HasOne(p => p.Bills).WithMany(p => p.BillDetails).HasForeignKey(p => p.IdBill);
    }
}