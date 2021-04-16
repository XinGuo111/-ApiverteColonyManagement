using System;

namespace Server.CQS.DTOs
{
    public class SpecialInspectionDto
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public long CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public long LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public Guid? UserId { get; set; }
        public Guid ColonyId { get; set; }
        public string[] Harvest { get; set; }
        public string[] Feeds { get; set; }
        public string[] Treatments { get; set; }
        public string[] TreatmentDetails { get; set; }
        public string[] Wintering { get; set; }
        public string Growth { get; set; }
    }
}
