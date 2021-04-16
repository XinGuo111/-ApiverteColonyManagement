using System;

namespace Server.DataModels
{
    public interface IEntity
    {
        Guid Id { get; set; }
        string CreatedBy { get; set; }
        long CreatedDate { get; set; }
        string LastModifiedBy { get; set; }
        long LastModifiedDate { get; set; }

        bool IsActive { get; set; }
    }

    public interface ILookupEntity
    {
        string Name { get; set; }
    }
}
