using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server.DataModels
{
    public class TypicalInspection : IEntity
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

        //Typical Inspection
        public string[] Weather { get; set; }
        public string Population { get; set; }
        public string Mood { get; set; }
        public string Fitness { get; set; }

        //Hive Bodies
        public int BroodChambers { get; set; }
        public int HoneyChamber { get; set; }
        public bool MouseGuard { get; set; }
        public bool WaspGuard { get; set; }
        public bool PollenCollector { get; set; }
        public string HiveBottom { get; set; }
        public string Vents { get; set; }

        //Frames
        public string Brood { get; set; }
        public string Honey { get; set; }
        public string BroodPattern { get; set; }
        public string[] Issues { get; set; }

        //Modifications
        public string[] Growth { get; set; }
        public string[] Seasonal { get; set; }

        //Queen
        public string Status { get; set; }
        public string Cells { get; set; }
        public string SwarmStatus { get; set; }
        public bool Excluder { get; set; }

    }

    public class TypicalInspectionConfiguration : IEntityTypeConfiguration<TypicalInspection>
    {
        public void Configure(EntityTypeBuilder<TypicalInspection> builder)
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
                .WithMany(user => user.TypicalInspections)
                .HasForeignKey(inspection => inspection.UserID);
        }
    }
}
