using System;
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
    public class GetUsersQuery : IRequest<IEnumerable<LookupDto>>
    {
        public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<LookupDto>>
        {
            private readonly Context _db;

            public GetUsersQueryHandler(Context db)
            {
                _db = db;
            }
            public async Task<IEnumerable<LookupDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
            {
                return await _db.User.Select(u => new LookupDto()
                {
                    Id = u.Id,
                    Name = u.Name,
                    IsActive = u.IsActive,
                    CreatedBy = u.CreatedBy,
                    CreatedDate = u.CreatedDate,
                    LastModifiedBy = u.LastModifiedBy,
                    LastModifiedDate = u.LastModifiedDate,
                }).ToListAsync(cancellationToken: cancellationToken);
            }
        }
    }
}
