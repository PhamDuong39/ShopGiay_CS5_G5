using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    using Data.Models;

    using Microsoft.EntityFrameworkCore;

    public class SizeConfigurations : IEntityTypeConfiguration<Sizes>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Sizes> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.SizeNumber).HasColumnType("nvarchar(30)");
        }
    }
}
