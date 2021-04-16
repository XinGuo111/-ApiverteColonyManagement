using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Server.DataModels.Colony;

namespace Server.DataModels
{
    public class Context : DbContext
    {
        public DbSet<Colony.Colony> Colony { get; set; }
        public DbSet<Area> Area { get; set; }

        public DbSet<Host> Host { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<TypicalInspection> TypicalInspection { get; set; }

        public DbSet<SpecialInspection> SpecialInspection { get; set; }

        public Context()
        { }

        public Context(DbContextOptions<Context> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }
        public override int SaveChanges()
        {
            return SaveChanges(null);
        }

        public int SaveChanges(string overrideBy)
        {
            var entries = ChangeTracker.Entries().Where(t => t.State == EntityState.Modified || t.State == EntityState.Added);
            foreach (var entityEntry in entries)
            {
                SetPrimaryKey(entityEntry);
                SetCreatedTracking(entityEntry, overrideBy);
                SetTracking(entityEntry, overrideBy);
            }

            return base.SaveChanges();
        }

        private void SetTracking(EntityEntry entry, string overrideBy)
        {
            if (!(entry.Entity is IEntity entity)) return;
            if (Entry(entity).State != EntityState.Added && Entry(entity).State != EntityState.Modified) return;
            entity.LastModifiedDate = DateTime.UtcNow.Ticks;
            entity.LastModifiedBy = GetTrackingBy(overrideBy);
        }

        private void SetPrimaryKey(EntityEntry entry)
        {
            if (!(entry.Entity is IEntity entity)) return;

            if (Entry(entity).State == EntityState.Added && entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }
        }

        private void SetCreatedTracking(EntityEntry entry, string overrideBy)
        {
            if (!(entry.Entity is IEntity entity)) return;
            if (Entry(entity).State != EntityState.Added) return;
            if (!string.IsNullOrEmpty(entity.CreatedBy) && entity.CreatedDate != DateTime.MinValue.Second) return;
            entity.CreatedDate = DateTime.UtcNow.Ticks;
            entity.CreatedBy = GetTrackingBy(overrideBy);
        }

        private string GetTrackingBy(string overrideBy)
        {
            return overrideBy ?? "System";
        }
    }
}
