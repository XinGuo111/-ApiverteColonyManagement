using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.CQS.Commands;
using Server.CQS.DTOs;
using Server.DataModels;

namespace Server.CQS.Queries
{
    public class GetSpecialInspectionsQuery : IRequest<IEnumerable<SpecialInspectionDto>>
    {
        public class GetSpecialInspectionsQueryHandler : IRequestHandler<GetSpecialInspectionsQuery, IEnumerable<SpecialInspectionDto>>
        {
            private readonly Context _db;

            public GetSpecialInspectionsQueryHandler(Context db)
            {
                _db = db;
            }
            public async Task<IEnumerable<SpecialInspectionDto>> Handle(GetSpecialInspectionsQuery request, CancellationToken cancellationToken)
            {
                return await _db.SpecialInspection.Select(i => new SpecialInspectionDto()
                {
                    Id = i.Id,
                    CreatedBy = i.CreatedBy,
                    CreatedDate = i.CreatedDate,
                    LastModifiedBy = i.LastModifiedBy,
                    LastModifiedDate = i.LastModifiedDate,
                    IsActive = i.IsActive,
                    UserId = i.UserID,
                    ColonyId = i.ColonyId,
                    Harvest = i.Harvest,
                    Feeds = i.Feeds,
                    Treatments = i.Treatments,
                    TreatmentDetails = i.TreatmentDetails,
                    Wintering = i.Wintering,
                    Growth = i.Growth
                }).ToListAsync(cancellationToken: cancellationToken);
            }
        }
    }
}
