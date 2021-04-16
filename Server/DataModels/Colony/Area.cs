using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server.DataModels.Colony
{
    public class Area : IEntity, ILookupEntity
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

    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.HasKey(area => area.Id);

            builder.Property(area => area.IsActive)
                .HasDefaultValue(false);
            builder.Property(area => area.CreatedBy)
                .HasDefaultValue("System");
            builder.Property(area => area.LastModifiedBy)
                .HasDefaultValue("System");
            builder.Property(area => area.CreatedDate)
                .HasDefaultValue(DateTime.Now.Ticks);
            builder.Property(area => area.LastModifiedDate)
                .HasDefaultValue(DateTime.Now.Ticks);

        }
    }
}
