using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server.DataModels
{
    public class User : IEntity, ILookupEntity
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public long CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public long LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<TypicalInspection> TypicalInspections { get; set; }
        public virtual IEnumerable<SpecialInspection> SpecialInspections { get; set; }
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.IsActive)
                .HasDefaultValue(false);
            builder.Property(user => user.CreatedBy)
                .HasDefaultValue("System");
            builder.Property(user => user.LastModifiedBy)
                .HasDefaultValue("System");
            builder.Property(user => user.CreatedDate)
                .HasDefaultValue(DateTime.Now.Ticks);
            builder.Property(user => user.LastModifiedDate)
                .HasDefaultValue(DateTime.Now.Ticks);
        }
    }
}
