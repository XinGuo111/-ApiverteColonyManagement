using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Server.CQS.DTOs;
using Server.DataModels;

namespace Server.CQS.Commands.Colony
{
    public class SyncColonyCommand : IRequest<IEnumerable<ColonyDto>>
    {
        public List<ColonyDto> Colonies { get; set; }
    }

    public class SyncColonyCommandHandler : IRequestHandler<SyncColonyCommand, IEnumerable<ColonyDto>>
    {
        private readonly Context _db;

        public SyncColonyCommandHandler(Context db)
        {
            _db = db;
        }
        public Task<IEnumerable<ColonyDto>> Handle(SyncColonyCommand request, CancellationToken cancellationToken)
        {
            var colonies = request.Colonies ?? new List<ColonyDto>();
            foreach (var appColonies in colonies)
            {
                var localColony = _db.Colony.FirstOrDefault(u => u.Id == appColonies.Id);
                DataModels.Colony.Colony colony = new DataModels.Colony.Colony()
                {
                    Id = appColonies.Id,
                    IsActive = appColonies.IsActive,
                    CreatedDate = appColonies.CreatedDate,
                    CreatedBy = appColonies.CreatedBy,
                    LastModifiedDate = appColonies.LastModifiedDate,
                    LastModifiedBy = appColonies.LastModifiedBy,
                    HostId = appColonies.HostId,
                    AreaId = appColonies.AreaId,
                    HiveNumber = appColonies.HiveNumber,
                    ColonyNumber = appColonies.ColonyNumber,
                    ColonySource = appColonies.ColonySource,
                    QueenType = appColonies.QueenType,
                    Markings = appColonies.Markings,
                    GeneticBreed = appColonies.GeneticBreed,
                    InstallationType = appColonies.InstallationType,
                    AdditionalInfo = appColonies.AdditionalInfo,
                    InstallDate = appColonies.InstallDate,
                    HiveType = appColonies.HiveType,
                    BroodChamberType = appColonies.BroodChamberType,
                    QueenExclude = appColonies.QueenExclude
                };

                if (localColony == null)
                {
                    _db.Colony.Add(colony);
                }
                else if (appColonies.LastModifiedDate > localColony.LastModifiedDate)
                {
                    _db.Colony.Remove(localColony);
                    _db.Colony.Add(colony);
                }
                else
                {
                    appColonies.IsActive = localColony.IsActive;
                    appColonies.CreatedDate = localColony.CreatedDate;
                    appColonies.CreatedBy = localColony.CreatedBy;
                    appColonies.LastModifiedDate = localColony.LastModifiedDate;
                    appColonies.LastModifiedBy = localColony.LastModifiedBy;
                    appColonies.HostId = localColony.HostId;
                    appColonies.AreaId = localColony.AreaId;
                    appColonies.HiveNumber = localColony.HiveNumber;
                    appColonies.ColonyNumber = localColony.ColonyNumber;
                    appColonies.ColonySource = localColony.ColonySource;
                    appColonies.QueenType = localColony.QueenType;
                    appColonies.Markings = localColony.Markings;
                    appColonies.GeneticBreed = localColony.GeneticBreed;
                    appColonies.InstallationType = localColony.InstallationType;
                    appColonies.AdditionalInfo = localColony.AdditionalInfo;
                    appColonies.InstallDate = localColony.InstallDate;
                    appColonies.HiveType = localColony.HiveType;
                    appColonies.BroodChamberType = localColony.BroodChamberType;
                    appColonies.QueenExclude = localColony.QueenExclude;
                }
            }

            var appColonysIDs = colonies.Select(u => u.Id).ToList();
            var uniqueLocalColonies = _db.Colony.Where(u => !appColonysIDs.Contains(u.Id)).Select(u => new ColonyDto()
            {
                Id = u.Id,
                IsActive = u.IsActive,
                CreatedDate = u.CreatedDate,
                CreatedBy = u.CreatedBy,
                LastModifiedDate = u.LastModifiedDate,
                LastModifiedBy = u.LastModifiedBy,
                HostId = u.HostId,
                AreaId = u.AreaId,
                HiveNumber = u.HiveNumber,
                ColonyNumber = u.ColonyNumber,
                ColonySource = u.ColonySource,
                QueenType = u.QueenType,
                Markings = u.Markings,
                GeneticBreed = u.GeneticBreed,
                InstallationType = u.InstallationType,
                AdditionalInfo = u.AdditionalInfo,
                InstallDate = u.InstallDate,
                HiveType = u.HiveType,
                BroodChamberType = u.BroodChamberType,
                QueenExclude = u.QueenExclude
            }).ToList();

            colonies.AddRange(uniqueLocalColonies);
            _db.SaveChanges();

            return Task.FromResult<IEnumerable<ColonyDto>>(colonies);
        }
    }
}
