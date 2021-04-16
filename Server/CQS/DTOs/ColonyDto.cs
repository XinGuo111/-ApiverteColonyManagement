using System;

namespace Server.CQS.DTOs
{
    public class ColonyDto
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public long CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public long LastModifiedDate { get; set; }

        public Guid HostId { get; set; }

        public Guid AreaId { get; set; }

        public int HiveNumber { get; set; }

        public string ColonyNumber { get; set; }
        public string ColonySource { get; set; }
        public string QueenType { get; set; }

        public string Markings { get; set; }

        public string GeneticBreed { get; set; }

        public string InstallationType { get; set; }

        public string AdditionalInfo { get; set; }

        public long InstallDate { get; set; }

        public string HiveType { get; set; }
        public string BroodChamberType { get; set; }

        public bool QueenExclude { get; set; }
    }
}
