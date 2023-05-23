namespace Data.Configurations;

using Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class FavouriteShoesConfiguration : IEntityTypeConfiguration<FavouriteShoes>
{
    public void Configure(EntityTypeBuilder<FavouriteShoes> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(p => p.Users).WithMany(p => p.FavoriteShoes).HasForeignKey(p => p.IdUser);
        builder.HasOne(p => p.ShoeDetails).WithMany(p => p.FavoriteShoes).HasForeignKey(p => p.IdShoeDetail);
    }
}