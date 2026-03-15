using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Common;
using Server.Domain.Entities;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Claims;

namespace Server.Infrastructure.Data
{
    public class ApplicationDbContext
        : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            IHttpContextAccessor  httpContextAccessor    )
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var userId = _httpContextAccessor.HttpContext?
                            .User?.FindFirstValue(ClaimTypes.NameIdentifier);

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedOn = DateTime.UtcNow;
                    entry.Entity.CreatedBy = userId;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.LastModifiedOn = DateTime.UtcNow;
                    entry.Entity.LastModifiedBy = userId;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
        // DbSets
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Outfit> Outfits => Set<Outfit>();
        public DbSet<OutfitMeasurementField> OutfitMeasurementFields => Set<OutfitMeasurementField>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<MeasurementValue> MeasurementValues => Set<MeasurementValue>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customer
            builder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Outfit -> Measurement Fields
            builder.Entity<Outfit>()
                .HasMany(o => o.MeasurementFields)
                .WithOne(f => f.Outfit)
                .HasForeignKey(f => f.OutfitId)
                .OnDelete(DeleteBehavior.Cascade);

            // Order -> OrderItems
            builder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne(i => i.Order)
                .HasForeignKey(i => i.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // OrderItem -> Outfit
            builder.Entity<OrderItem>()
                .HasOne(i => i.Outfit)
                .WithMany()
                .HasForeignKey(i => i.OutfitId)
                .OnDelete(DeleteBehavior.Restrict);

            // OrderItem -> MeasurementValues
            builder.Entity<OrderItem>()
                .HasMany(i => i.Measurements)
                .WithOne(m => m.OrderItem)
                .HasForeignKey(m => m.OrderItemId)
                .OnDelete(DeleteBehavior.Cascade);

            // MeasurementValue -> OutfitMeasurementField
            builder.Entity<MeasurementValue>()
                .HasOne(m => m.Field)
                .WithMany()
                .HasForeignKey(m => m.OutfitMeasurementFieldId)
                .OnDelete(DeleteBehavior.Restrict);

            // Unique Order Number
            builder.Entity<Order>()
                .HasIndex(o => o.OrderNumber)
                .IsUnique();
            OutfitSeed.SeedOutfits(builder);
            // convertion of enums to string
            builder.Entity<Order>()
                .Property(o => o.Status)
                .HasConversion<string>();
            builder.Entity<Order>()
              .Property(o => o.PaymentStatus)
              .HasConversion<string>();
            builder.Entity<OrderItem>()
              .Property(o => o.Status)
              .HasConversion<string>();
            builder.Entity<OutfitMeasurementField>()
              .Property(o => o.FieldType)
              .HasConversion<string>();
            builder.Entity<OutfitMeasurementField>()
             .Property(o => o.Unit)
             .HasConversion<string>();

        }

        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    var entries = ChangeTracker
        //        .Entries<AuditableEntity>();

        //    var now = DateTime.UtcNow;

        //    foreach (var entry in entries)
        //    {
        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Entity.CreatedOn = now;
        //            // Later: inject current user service
        //            entry.Entity.CreatedBy ??= "System";
        //        }

        //        if (entry.State == EntityState.Modified)
        //        {
        //            entry.Entity.LastModifiedOn = now;
        //            entry.Entity.LastModifiedBy ??= "System";
        //        }
        //    }

        //    return await base.SaveChangesAsync(cancellationToken);
        //}
    }
}