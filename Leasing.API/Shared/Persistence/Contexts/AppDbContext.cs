

using Leasing.API.App.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Leasing.API.App.Shared.Persistence.Contexts;

public class AppDbContext:DbContext
{
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<FeeType> FeeTypes { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<RateType> RateTypes { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<VAT> VATs { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /*-----------------------Properties and keys-----------------------*/
            
            //AssetType
            builder.Entity<AssetType>().ToTable("AssetTypes");
            builder.Entity<AssetType>().HasKey(p => p.Id);
            builder.Entity<AssetType>().Property(p => p.Id).IsRequired();
            builder.Entity<AssetType>().Property(p => p.Name).HasMaxLength(50);
            
            //CurrencyType
            builder.Entity<CurrencyType>().ToTable("CurrencyTypes");
            builder.Entity<CurrencyType>().HasKey(p => p.Id);
            builder.Entity<CurrencyType>().Property(p => p.Id).IsRequired();
            builder.Entity<CurrencyType>().Property(p => p.CurrencyName).HasMaxLength(50);
            builder.Entity<CurrencyType>().Property(p => p.Price).HasMaxLength(50);
            
            //Fee
            builder.Entity<Fee>().ToTable("Fees");
            builder.Entity<Fee>().HasKey(p => p.Id);
            builder.Entity<Fee>().Property(p => p.Id).IsRequired();
            builder.Entity<Fee>().Property(p => p.Quantity).HasMaxLength(50);
            
            //FeeType
            builder.Entity<FeeType>().ToTable("FeeTypes");
            builder.Entity<FeeType>().HasKey(p => p.Id);
            builder.Entity<FeeType>().Property(p => p.Id).IsRequired();
            builder.Entity<FeeType>().Property(p => p.FeeName).HasMaxLength(50);
            
            //Period
            builder.Entity<Period>().ToTable("Periods");
            builder.Entity<Period>().HasKey(p => p.Id);
            builder.Entity<Period>().Property(p => p.Id).IsRequired();
            builder.Entity<Period>().Property(p => p.Quantity).HasMaxLength(50);

            //RateType
            builder.Entity<RateType>().ToTable("RateTypes");
            builder.Entity<RateType>().HasKey(p => p.Id);
            builder.Entity<RateType>().Property(p => p.Id).IsRequired();
            builder.Entity<RateType>().Property(p => p.RateName).HasMaxLength(50);
            builder.Entity<RateType>().Property(p => p.Percentage).HasMaxLength(50);
            
            //Solution
            builder.Entity<Solution>().ToTable("Solutions");
            builder.Entity<Solution>().HasKey(p => p.Id);
            builder.Entity<Solution>().Property(p => p.Id).IsRequired();
            builder.Entity<Solution>().Property(p => p.LoanDate).HasMaxLength(50);
            builder.Entity<Solution>().Property(p => p.FirstPaymentDate).HasMaxLength(50);
            builder.Entity<Solution>().Property(p => p.Value).HasMaxLength(50);

            //Time
            builder.Entity<Time>().ToTable("Times");
            builder.Entity<Time>().HasKey(p => p.Id);
            builder.Entity<Time>().Property(p => p.Id).IsRequired();
            builder.Entity<Time>().Property(p => p.TimeUnit).HasMaxLength(50);

            //User
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired();
            builder.Entity<User>().Property(p => p.Email).HasMaxLength(50);
            builder.Entity<User>().Property(p => p.Password).HasMaxLength(50);
            
            //UserProfile
            builder.Entity<UserProfile>().ToTable("UserProfiles");
            builder.Entity<UserProfile>().HasKey(p => p.Id);
            builder.Entity<UserProfile>().Property(p => p.Id).IsRequired();
            builder.Entity<UserProfile>().Property(p => p.FirstName).HasMaxLength(50);
            builder.Entity<UserProfile>().Property(p => p.LastName).HasMaxLength(50);

            //VAT
            builder.Entity<VAT>().ToTable("Users");
            builder.Entity<VAT>().HasKey(p => p.Id);
            builder.Entity<VAT>().Property(p => p.Id).IsRequired();
            builder.Entity<VAT>().Property(p => p.Percentage).HasMaxLength(50);
            
            /*----------------------- Relationships and Foreignkeys -----------------------*/
            
            // --------------------------- AssetType -------------------------------- //
            
            //AssetType with Solution
            builder.Entity<AssetType>()
                .HasMany(p => p.Solutions)
                .WithOne(p => p.AssetType)
                .HasForeignKey(p => p.AssetTypeId);

            // --------------------------- CurrencyType -------------------------------- //
            builder.Entity<CurrencyType>()
                .HasMany(p => p.Solutions)
                .WithOne(p => p.CurrencyType)
                .HasForeignKey(p => p.CurrencyTypeId);
            // --------------------------- Fee -------------------------------- //
            builder.Entity<Fee>()
                .HasMany(p => p.Solutions)
                .WithOne(p => p.Fee)
                .HasForeignKey(p => p.FeeId);
            // --------------------------- FeeType -------------------------------- //
            builder.Entity<FeeType>()
                .HasMany(p => p.Fees)
                .WithOne(p => p.FeeType)
                .HasForeignKey(p => p.FeeTypeId);
            // --------------------------- Period -------------------------------- //
            builder.Entity<Period>()
                .HasMany(p => p.Solutions)
                .WithOne(p => p.Period)
                .HasForeignKey(p => p.PeriodId);
            // --------------------------- RateType -------------------------------- //
            builder.Entity<RateType>()
                .HasMany(p => p.Solutions)
                .WithOne(p => p.RateType)
                .HasForeignKey(p => p.RateTypeId);
            // --------------------------- Time -------------------------------- //
            builder.Entity<Time>()
                .HasMany(p => p.Periods)
                .WithOne(p => p.Time)
                .HasForeignKey(p => p.TimeId);
            // --------------------------- User -------------------------------- //
            builder.Entity<User>()
                .HasMany(p => p.ProfileUsers)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
            // --------------------------- UserProfile -------------------------------- //
            builder.Entity<UserProfile>()
                .HasMany(p => p.Solutions)
                .WithOne(p => p.UserProfile)
                .HasForeignKey(p => p.UserProfileId);
            // --------------------------- VAT -------------------------------- //
            builder.Entity<VAT>()
                .HasMany(p => p.Solutions)
                .WithOne(p => p.VAT)
                .HasForeignKey(p => p.VATId);
        }
}
