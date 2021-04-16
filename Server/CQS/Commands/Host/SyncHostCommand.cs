using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Server.CQS.DTOs;
using Server.DataModels;

namespace Server.CQS.Commands.Host
{
    public class SyncHostCommand : IRequest<IEnumerable<LookupDto>>
    {
        public List<LookupDto> Hosts { get; set; }

        public class SyncHostCommandHandler : IRequestHandler<SyncHostCommand, IEnumerable<LookupDto>>
        {
            private readonly Context _db;

            public SyncHostCommandHandler(Context db)
            {
                _db = db;
            }

            public Task<IEnumerable<LookupDto>> Handle(SyncHostCommand request, CancellationToken cancellationToken)
            {
                var hosts = request.Hosts ?? new List<LookupDto>();
                foreach (var apphosts in hosts)
                {
                    var localhost = _db.Host.FirstOrDefault(u => u.Id == apphosts.Id);
                    DataModels.Colony.Host host = new DataModels.Colony.Host()
                    {
                        Id = apphosts.Id,
                        Name = apphosts.Name,
                        IsActive = apphosts.IsActive,
                        CreatedDate = apphosts.CreatedDate,
                        CreatedBy = apphosts.CreatedBy,
                        LastModifiedDate = apphosts.LastModifiedDate,
                        LastModifiedBy = apphosts.LastModifiedBy
                    };

                    if (localhost == null)
                    {
                        _db.Host.Add(host);
                    }
                    else if (apphosts.LastModifiedDate > localhost.LastModifiedDate)
                    {
                        _db.Host.Remove(localhost);
                        _db.Host.Add(host);
                    }
                    else
                    {
                        apphosts.Name = localhost.Name;
                        apphosts.IsActive = localhost.IsActive;
                        apphosts.CreatedDate = localhost.CreatedDate;
                        apphosts.CreatedBy = localhost.CreatedBy;
                        apphosts.LastModifiedDate = localhost.LastModifiedDate;
                        apphosts.LastModifiedBy = localhost.LastModifiedBy;
                    }
                }

                var apphostsIDs = hosts.Select(u => u.Id).ToList();
                var uniqueLocalhosts = _db.Host.Where(u => !apphostsIDs.Contains(u.Id)).Select(u => new LookupDto()
                {
                    Id = u.Id,
                    Name = u.Name,
                    IsActive = u.IsActive,
                    CreatedDate = u.CreatedDate,
                    CreatedBy = u.CreatedBy,
                    LastModifiedDate = u.LastModifiedDate,
                    LastModifiedBy = u.LastModifiedBy
                }).ToList();

                hosts.AddRange(uniqueLocalhosts);
                _db.SaveChanges();

                return Task.FromResult<IEnumerable<LookupDto>>(hosts);
            }
        }
    }
}
