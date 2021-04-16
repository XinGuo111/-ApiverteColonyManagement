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
    public class GetTypicalInspectionQuery : IRequest<IEnumerable<TypicalInspectionDto>>
    {
        public class GetTypicalInspectionQueryHandler : IRequestHandler<GetTypicalInspectionQuery, IEnumerable<TypicalInspectionDto>>
        {
            private readonly Context _db;

            public GetTypicalInspectionQueryHandler(Context db)
            {
                _db = db;
            }
            public async Task<IEnumerable<TypicalInspectionDto>> Handle(GetTypicalInspectionQuery request, CancellationToken cancellationToken)
            {
                return await _db.TypicalInspection.Select(i => new TypicalInspectionDto()
                {
                    Id = i.Id,
                    CreatedBy = i.CreatedBy,
                    CreatedDate = i.CreatedDate,
                    LastModifiedBy = i.LastModifiedBy,
                    LastModifiedDate = i.LastModifiedDate,
                    UserId = i.UserID,
                    ColonyId = i.ColonyId,
                    Weather = i.Weather,
                    Population = i.Population,
                    Mood = i.Mood,
                    Fitness = i.Fitness,
                    BroodChambers = i.BroodChambers,
                    HoneyChamber = i.HoneyChamber,
                    MouseGuard = i.MouseGuard,
                    WaspGuard = i.WaspGuard,
                    PollenCollector = i.PollenCollector,
                    HiveBottom = i.HiveBottom,
                    Vents = i.Vents,
                    Brood = i.Brood,
                    Honey = i.Honey,
                    BroodPattern = i.BroodPattern,
                    Issues = i.Issues,
                    Growth = i.Growth,
                    Seasonal = i.Seasonal,
                    Status = i.Status,
                    Cells = i.Cells,
                    SwarmStatus = i.SwarmStatus,
                    Excluder = i.Excluder
                }).ToListAsync(cancellationToken: cancellationToken);
            }
        }
    }
}
