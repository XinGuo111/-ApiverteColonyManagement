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
    public class GetHostsQuery : IRequest<IEnumerable<LookupDto>>
    {
        public class GetHostsQueryHandler : IRequestHandler<GetHostsQuery, IEnumerable<LookupDto>>
        {
            private readonly Context _db;

            public GetHostsQueryHandler(Context db)
            {
                _db = db;
            }

            public async Task<IEnumerable<LookupDto>> Handle(GetHostsQuery request, CancellationToken cancellationToken)
            {
                return await _db.Host.Select(h => new LookupDto()
                {
                    Id = h.Id,
                    Name = h.Name,
                    IsActive = h.IsActive,
                    CreatedBy = h.CreatedBy,
                    CreatedDate = h.CreatedDate,
                    LastModifiedBy = h.LastModifiedBy,
                    LastModifiedDate = h.LastModifiedDate,
                }).ToListAsync(cancellationToken: cancellationToken);
            }
        }
    }
}
