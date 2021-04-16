using System;

namespace Server.CQS.DTOs
{
    public class LookupDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }
        public long CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public long LastModifiedDate { get; set; }

    }
}
