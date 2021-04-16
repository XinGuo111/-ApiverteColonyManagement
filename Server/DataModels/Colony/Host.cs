using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server.DataModels.Colony
{
    public class Host : IEntity, ILookupEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public long CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public long LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual IEnumerable<Colony> Colonies { get; set; }
    }

    public class HostConfiguration : IEntityTypeConfiguration<Host>
    {
        public void Configure(EntityTypeBuilder<Host> builder)
        {
            builder.HasKey(host => host.Id);
            builder.Property(host => host.IsActive)
                .HasDefaultValue(false);
            builder.Property(host => host.CreatedBy)
                .HasDefaultValue("System");
            builder.Property(host => host.LastModifiedBy)
                .HasDefaultValue("System");
            builder.Property(host => host.CreatedDate)
                .HasDefaultValue(DateTime.Now.Ticks);
            builder.Property(host => host.LastModifiedDate)
                .HasDefaultValue(DateTime.Now.Ticks);
        }
    }
}
