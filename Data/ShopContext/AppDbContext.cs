namespace Data.ShopContext;

using System.Reflection;

using Data.Models;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<AchivePoint> AchivePoints { get; set; }

    public DbSet<BillDetails> BillDetails { get; set; }

    public DbSet<Bills> Bills { get; set; }

    public DbSet<Brands> Brands { get; set; }

    public DbSet<CartDetails> CartDetails { get; set; }

    public DbSet<Carts> Carts { get; set; }

    public DbSet<Categories> Categories { get; set; }

    public DbSet<Color_ShoeDetails> Color_ShoeDetails { get; set; }

    public DbSet<Colors> Colors { get; set; }

    public DbSet<Coupons> Coupons { get; set; }

    public DbSet<Descriptions> Descriptions { get; set; }

    public DbSet<FavouriteShoes> FavouriteShoes { get; set; }

    public DbSet<Feedbacks> Feedbacks { get; set; }

    public DbSet<Images> Images { get; set; }

    public DbSet<Location> Location { get; set; }

    public DbSet<PaymentMethods> PaymentMethods { get; set; }

    public DbSet<Roles> Roles { get; set; }

    public DbSet<Sales> Sales { get; set; }

    public DbSet<ShipAdressMethod> ShipAdressMethods { get; set; }

    public DbSet<ShoeDetails> ShoeDetails { get; set; }

    public DbSet<Sizes> Sizes { get; set; }

    public DbSet<Sizes_ShoeDetails> Sizes_ShoeDetails { get; set; }

    public DbSet<Supplier> Suppliers { get; set; }

    public DbSet<Users> users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Data Source=DTHAI16GG\\SQLEXPRESS;Initial Catalog = ShoesShopDB;Integrated Security=True;Trust Server Certificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    // public DbSet<AchivePoint> AchivePoints { get; set; }
}