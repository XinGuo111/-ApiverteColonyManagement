using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Server.CQS.DTOs;
using Server.DataModels;

namespace Server.CQS.Commands.Area
{
    public class SyncAreaCommand : IRequest<IEnumerable<LookupDto>>
    {
        public List<LookupDto> Areas { get; set; }

        public class SyncAreaCommandHandler : IRequestHandler<SyncAreaCommand, IEnumerable<LookupDto>>
        {
            private readonly Context _db;

            public SyncAreaCommandHandler(Context db)
            {
                _db = db;
            }

            public Task<IEnumerable<LookupDto>> Handle(SyncAreaCommand request, CancellationToken cancellationToken)
            {
                var areas = request.Areas ?? new List<LookupDto>();
                foreach (var appAreas in areas)
                {
                    var localArea = _db.Area.FirstOrDefault(u => u.Id == appAreas.Id);
                    DataModels.Colony.Area area = new DataModels.Colony.Area()
                    {
                        Id = appAreas.Id,
                        Name = appAreas.Name,
                        IsActive = appAreas.IsActive,
                        CreatedDate = appAreas.CreatedDate,
                        CreatedBy = appAreas.CreatedBy,
                        LastModifiedDate = appAreas.LastModifiedDate,
                        LastModifiedBy = appAreas.LastModifiedBy
                    };

                    if (localArea == null)
                    {
                        _db.Area.Add(area);
                    }
                    else if (appAreas.LastModifiedDate > localArea.LastModifiedDate)
                    {
                        _db.Area.Remove(localArea);
                        _db.Area.Add(area);
                    }
                    else
                    {
                        appAreas.Name = localArea.Name;
                        appAreas.IsActive = localArea.IsActive;
                        appAreas.CreatedDate = localArea.CreatedDate;
                        appAreas.CreatedBy = localArea.CreatedBy;
                        appAreas.LastModifiedDate = localArea.LastModifiedDate;
                        appAreas.LastModifiedBy = localArea.LastModifiedBy;
                    }
                }

                var appAreasIDs = areas.Select(u => u.Id).ToList();
                var uniqueLocalAreas = _db.Area.Where(u => !appAreasIDs.Contains(u.Id)).Select(u => new LookupDto()
                {
                    Id = u.Id,
                    Name = u.Name,
                    IsActive = u.IsActive,
                    CreatedDate = u.CreatedDate,
                    CreatedBy = u.CreatedBy,
                    LastModifiedDate = u.LastModifiedDate,
                    LastModifiedBy = u.LastModifiedBy
                }).ToList();

                areas.AddRange(uniqueLocalAreas);
                _db.SaveChanges();

                return Task.FromResult<IEnumerable<LookupDto>>(areas);
            }
        }
    }
}
