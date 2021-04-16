using System;

namespace Server.CQS.DTOs
{
    public class TypicalInspectionDto
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public long CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public long LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public Guid? UserId { get; set; }

        public Guid ColonyId { get; set; }

        public string[] Weather { get; set; }
        public string Population { get; set; }
        public string Mood { get; set; }
        public string Fitness { get; set; }

        public int BroodChambers { get; set; }
        public int HoneyChamber { get; set; }
        public bool MouseGuard { get; set; }
        public bool WaspGuard { get; set; }
        public bool PollenCollector { get; set; }
        public string HiveBottom { get; set; }
        public string Vents { get; set; }

        public string Brood { get; set; }
        public string Honey { get; set; }
        public string BroodPattern { get; set; }
        public string[] Issues { get; set; }

        public string[] Growth { get; set; }
        public string[] Seasonal { get; set; }

        public string Status { get; set; }
        public string Cells { get; set; }
        public string SwarmStatus { get; set; }
        public bool Excluder { get; set; }
    }
}
