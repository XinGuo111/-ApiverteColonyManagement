using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.CQS.DTOs;
using Server.DataModels;

namespace Server.CQS.Queries
{
    public class GetColoniesQuery : IRequest<IEnumerable<ColonyDto>>
    {
        public class GetColoniesQueryHandler : IRequestHandler<GetColoniesQuery, IEnumerable<ColonyDto>>
        {
            private readonly Context _db;

            public GetColoniesQueryHandler(Context db)
            {
                _db = db;
            }
            public async Task<IEnumerable<ColonyDto>> Handle(GetColoniesQuery request, CancellationToken cancellationToken)
            {
                return await _db.Colony.Select(c => new ColonyDto()
                {
                    Id = c.Id,
                    IsActive = c.IsActive,
                    CreatedBy = c.CreatedBy,
                    CreatedDate = c.CreatedDate,
                    LastModifiedBy = c.LastModifiedBy,
                    LastModifiedDate = c.LastModifiedDate,
                    HostId = c.HostId,
                    AreaId = c.AreaId,
                    HiveNumber = c.HiveNumber,
                    ColonyNumber = c.ColonyNumber,
                    ColonySource = c.ColonySource,
                    QueenType = c.QueenType,
                    Markings = c.Markings,
                    GeneticBreed = c.GeneticBreed,
                    InstallationType = c.InstallationType,
                    AdditionalInfo = c.AdditionalInfo,
                    InstallDate = c.InstallDate,
                    HiveType = c.HiveType,
                    BroodChamberType = c.BroodChamberType,
                    QueenExclude = c.QueenExclude

                }).ToListAsync(cancellationToken: cancellationToken);
            }
        }
    }
}
