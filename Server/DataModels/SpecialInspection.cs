using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server.DataModels
{
    public class SpecialInspection : IEntity
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public long CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public long LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public Guid? UserID { get; set; }
        public virtual User User { get; set; }

        //Identify Colony
        public Guid ColonyId { get; set; }
        public virtual Colony.Colony Colony { get; set; }

        //Special Inspection
        public string[] Harvest { get; set; }
        public string[] Feeds { get; set; }
        public string[] Treatments { get; set; }

        public string[] TreatmentDetails { get; set; }

        public string[] Wintering { get; set; }
        public string Growth { get; set; }
    }

    public class SpecialInspectionConfiguration : IEntityTypeConfiguration<SpecialInspection>
    {
        public void Configure(EntityTypeBuilder<SpecialInspection> builder)
        {
            builder.HasKey(inspection => inspection.Id);

            builder.Property(inspection => inspection.IsActive)
                .HasDefaultValue(false);
            builder.Property(inspection => inspection.CreatedBy)
                .HasDefaultValue("System");
            builder.Property(inspection => inspection.LastModifiedBy)
                .HasDefaultValue("System");
            builder.Property(inspection => inspection.CreatedDate)
                .HasDefaultValue(DateTime.Now.Ticks);
            builder.Property(inspection => inspection.LastModifiedDate)
                .HasDefaultValue(DateTime.Now.Ticks);

            builder.HasOne(inspection => inspection.User)
                .WithMany(user => user.SpecialInspections)
                .HasForeignKey(inspection => inspection.UserID);
        }
    }
}
