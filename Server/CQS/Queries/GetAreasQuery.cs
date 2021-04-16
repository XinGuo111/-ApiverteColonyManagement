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
    public class GetAreasQuery : IRequest<IEnumerable<LookupDto>>
    {
        public class GetAreasQueryHandler : IRequestHandler<GetAreasQuery, IEnumerable<LookupDto>>
        {
            private readonly Context _db;

            public GetAreasQueryHandler(Context db)
            {
                _db = db;
            }
            public async Task<IEnumerable<LookupDto>> Handle(GetAreasQuery request, CancellationToken cancellationToken)
            {
                return await _db.Area.Select(a => new LookupDto()
                {
                    Id = a.Id,
                    Name = a.Name,
                    IsActive = a.IsActive,
                    CreatedBy = a.CreatedBy,
                    CreatedDate = a.CreatedDate,
                    LastModifiedBy = a.LastModifiedBy,
                    LastModifiedDate = a.LastModifiedDate,
                }).ToListAsync(cancellationToken: cancellationToken);
            }
        }
    }

}
