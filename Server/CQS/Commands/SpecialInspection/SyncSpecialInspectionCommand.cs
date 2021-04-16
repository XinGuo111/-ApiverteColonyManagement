using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Server.CQS.DTOs;
using Server.DataModels;

namespace Server.CQS.Commands.SpecialInspection
{
    public class SyncSpecialInspectionCommand : IRequest<IEnumerable<SpecialInspectionDto>>
    {
        public List<SpecialInspectionDto> Inspections { get; set; }

        public class SyncSpecialInspectionCommandHandler : IRequestHandler<SyncSpecialInspectionCommand, IEnumerable<SpecialInspectionDto>>
        {
            private readonly Context _db;
            public SyncSpecialInspectionCommandHandler(Context db)
            {
                _db = db;
            }
            public Task<IEnumerable<SpecialInspectionDto>> Handle(SyncSpecialInspectionCommand request, CancellationToken cancellationToken)
            {
                var inspections = request.Inspections ?? new List<SpecialInspectionDto>();
                foreach (var appInspections in inspections)
                {
                    var localInspection = _db.SpecialInspection.FirstOrDefault(u => u.Id == appInspections.Id);
                    DataModels.SpecialInspection inspection = new DataModels.SpecialInspection()
                    {
                        Id = appInspections.Id,
                        IsActive = appInspections.IsActive,
                        CreatedDate = appInspections.CreatedDate,
                        CreatedBy = appInspections.CreatedBy,
                        LastModifiedDate = appInspections.LastModifiedDate,
                        LastModifiedBy = appInspections.LastModifiedBy,
                        UserID = appInspections.UserId,
                        ColonyId = appInspections.ColonyId,
                        Harvest = appInspections.Harvest,
                        Feeds = appInspections.Feeds,
                        Treatments = appInspections.Treatments,
                        TreatmentDetails = appInspections.TreatmentDetails,
                        Wintering = appInspections.Wintering,
                        Growth = appInspections.Growth,
                    };

                    if (localInspection == null)
                    {
                        _db.SpecialInspection.Add(inspection);
                    }
                    else if (appInspections.LastModifiedDate > localInspection.LastModifiedDate)
                    {
                        _db.SpecialInspection.Remove(localInspection);
                        _db.SpecialInspection.Add(inspection);
                    }
                    else
                    {
                        appInspections.IsActive = localInspection.IsActive;
                        appInspections.CreatedDate = localInspection.CreatedDate;
                        appInspections.CreatedBy = localInspection.CreatedBy;
                        appInspections.LastModifiedDate = localInspection.LastModifiedDate;
                        appInspections.LastModifiedBy = localInspection.LastModifiedBy;
                        appInspections.UserId = localInspection.UserID;
                        appInspections.ColonyId = localInspection.ColonyId;
                        appInspections.Harvest = localInspection.Harvest;
                        appInspections.Feeds = localInspection.Feeds;
                        appInspections.Treatments = localInspection.Treatments;
                        appInspections.TreatmentDetails = localInspection.TreatmentDetails;
                        appInspections.Wintering = localInspection.Wintering;
                        appInspections.Growth = localInspection.Growth;
                    }
                }

                var appInspectionIds = inspections.Select(u => u.Id).ToList();
                var uniqueLocalInspection = _db.SpecialInspection.Where(u => !appInspectionIds.Contains(u.Id)).Select(u => new SpecialInspectionDto()
                {
                    Id = u.Id,
                    IsActive = u.IsActive,
                    CreatedDate = u.CreatedDate,
                    CreatedBy = u.CreatedBy,
                    LastModifiedDate = u.LastModifiedDate,
                    LastModifiedBy = u.LastModifiedBy,
                    UserId = u.UserID,
                    ColonyId = u.ColonyId,
                    Harvest = u.Harvest,
                    Feeds = u.Feeds,
                    Treatments = u.Treatments,
                    TreatmentDetails = u.TreatmentDetails,
                    Wintering = u.Wintering,
                    Growth = u.Growth,
                }).ToList();

                inspections.AddRange(uniqueLocalInspection);
                _db.SaveChanges();

                return Task.FromResult<IEnumerable<SpecialInspectionDto>>(inspections);
            }
        }
    }
}
