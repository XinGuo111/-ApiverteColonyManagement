using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server.DataModels.Colony
{
    public class Colony : IEntity
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public long CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public long LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        //Colony Location
        public Guid HostId { get; set; }
        public virtual Host Host { get; set; }

        public Guid AreaId { get; set; }
        public virtual Area Area { get; set; }

        public int HiveNumber { get; set; }

        public string ColonyNumber { get; set; }

        //Colony Characteristic
        public string ColonySource { get; set; }
        public string QueenType { get; set; }

        public string Markings { get; set; }

        public string GeneticBreed { get; set; }

        public string InstallationType { get; set; }

        public string AdditionalInfo { get; set; }

        //Colony Setup
        public long InstallDate { get; set; }

        public string HiveType { get; set; }
        public string BroodChamberType { get; set; }

        public bool QueenExclude { get; set; }


    }

    public class ColonyConfiguration : IEntityTypeConfiguration<Colony>
    {
        public void Configure(EntityTypeBuilder<Colony> builder)
        {
            builder.HasKey(colony => colony.Id);

            builder.Property(colony => colony.IsActive)
                .HasDefaultValue(false);
            builder.Property(colony => colony.CreatedBy)
                .HasDefaultValue("System");
            builder.Property(colony => colony.LastModifiedBy)
                .HasDefaultValue("System");
            builder.Property(colony => colony.CreatedDate)
                .HasDefaultValue(DateTime.Now.Ticks);
            builder.Property(colony => colony.LastModifiedDate)
                .HasDefaultValue(DateTime.Now.Ticks);

            builder.HasOne(colony => colony.Host)
                .WithMany(host => host.Colonies)
                .HasForeignKey(colony => colony.HostId);

            builder.HasOne(colony => colony.Area)
                .WithMany(area => area.Colonies)
                .HasForeignKey(colony => colony.AreaId);
        }
    }
}
