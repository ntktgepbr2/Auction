using Auction.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Auction.Data.DatabaseContext
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<ItemLot> Lots { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@gmail.com";
            string adminPassword = "123456";

            Role adminRole = new Role { Name = adminRoleName };
            Role userRole = new Role { Name = userRoleName };
            User adminUser = new User { Id = Guid.NewGuid(), Name = adminEmail, Email = adminEmail, Password = adminPassword };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            //modelBuilder.Entity<User>().HasData(new User[] { adminUser });

            modelBuilder.Entity<User>(UserConfigure);
            modelBuilder.Entity<ItemLot>(ItemLotConfigure);
            modelBuilder.Entity<Role>(RoleConfigure);

        }

        public void UserConfigure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Password).IsRequired().HasMaxLength(60);
            builder.Property(p => p.Id).HasColumnType("uniqueidentifier");
            builder.Property(p => p.Salt).IsRequired().HasMaxLength(30);
        }
        public void ItemLotConfigure(EntityTypeBuilder<ItemLot> builder)
        {
            builder.ToTable("Lots").Property(c => c.Name).IsRequired().HasMaxLength(30);
            builder.HasOne(i => i.User).WithMany(u => u.ItemLots).OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.StartedPrice).IsRequired().HasColumnType("decimal(10,2)");
            builder.Property(p => p.CurrentPrice).HasColumnType("decimal(10,2)");
            builder.Property(p => p.Id).HasColumnType("uniqueidentifier");
            builder.Property(p => p.LastUserBidId).HasColumnType("uniqueidentifier");
        }
        public void RoleConfigure(EntityTypeBuilder<Role> builder)
        {

            builder.ToTable("Role").Property(c => c.Name).HasConversion(n => n.ToLowerInvariant(), n => n).IsRequired().HasMaxLength(30);
            builder.HasMany(x => x.Users).WithMany(u => u.Roles).UsingEntity(join => join.ToTable("UserRole"));
            builder.HasKey(i => i.Name);

        }
    }
}
