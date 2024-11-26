using BeautyShopDataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BeautyShopDataAccess;

public class BeautyShopDbContext : DbContext
{
    public BeautyShopDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<CardEntity> Cards { get; set; }
    public DbSet<OrderProductEntity> OrderProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("user_claims");
        modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("user_logins").HasNoKey();
        modelBuilder.Entity<IdentityUserToken<int>>().ToTable("user_tokens").HasNoKey();
        modelBuilder.Entity<IdentityRole<int>>().ToTable("user_roles");
        modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("user_roles_claims");
        modelBuilder.Entity<IdentityUserRole<int>>().ToTable("user_role_owners").HasNoKey();

        
        modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<ProductEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<ProductEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<OrderEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<OrderEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<CardEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<CardEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<OrderProductEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<OrderProductEntity>().HasIndex(x => x.ExternalId).IsUnique();

        modelBuilder.Entity<OrderEntity>().HasOne(x => x.User)
            .WithMany(x => x.Orders).HasForeignKey(x => x.UserId);

        modelBuilder.Entity<CardEntity>().HasOne(x => x.User)
            .WithMany(x => x.Cards).HasForeignKey(x => x.UserId);

        modelBuilder.Entity<OrderProductEntity>().HasOne(x => x.Order)
            .WithMany(x => x.OrderProducts).HasForeignKey(x => x.OrderId);

        modelBuilder.Entity<OrderProductEntity>().HasOne(x => x.Product)
            .WithMany(x => x.OrderProducts).HasForeignKey(x => x.ProductId);
    }
}