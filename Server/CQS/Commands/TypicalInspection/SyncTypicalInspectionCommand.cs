using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Server.CQS.DTOs;
using Server.DataModels;

namespace Server.CQS.Commands.TypicalInspection
{
    public class SyncTypicalInspectionCommand : IRequest<IEnumerable<TypicalInspectionDto>>
    {
        public List<TypicalInspectionDto> Inspections { get; set; }

        public class SyncTypicalInspectionCommandHandler : IRequestHandler<SyncTypicalInspectionCommand, IEnumerable<TypicalInspectionDto>>
        {
            private readonly Context _db;
            public SyncTypicalInspectionCommandHandler(Context db)
            {
                _db = db;
            }
            public Task<IEnumerable<TypicalInspectionDto>> Handle(SyncTypicalInspectionCommand request, CancellationToken cancellationToken)
            {
                var inspections = request.Inspections ?? new List<TypicalInspectionDto>();
                foreach (var appInspections in inspections)
                {
                    var localInspection = _db.TypicalInspection.FirstOrDefault(u => u.Id == appInspections.Id);
                    DataModels.TypicalInspection inspection = new DataModels.TypicalInspection()
                    {
                        Id = appInspections.Id,
                        IsActive = appInspections.IsActive,
                        CreatedDate = appInspections.CreatedDate,
                        CreatedBy = appInspections.CreatedBy,
                        LastModifiedDate = appInspections.LastModifiedDate,
                        LastModifiedBy = appInspections.LastModifiedBy,
                        UserID = appInspections.UserId,
                        ColonyId = appInspections.ColonyId,
                        Weather = appInspections.Weather,
                        Population = appInspections.Population,
                        Mood = appInspections.Mood,
                        Fitness = appInspections.Fitness,
                        BroodChambers = appInspections.BroodChambers,
                        HoneyChamber = appInspections.HoneyChamber,
                        MouseGuard = appInspections.MouseGuard,
                        WaspGuard = appInspections.WaspGuard,
                        PollenCollector = appInspections.PollenCollector,
                        HiveBottom = appInspections.HiveBottom,
                        Vents = appInspections.Vents,
                        Brood = appInspections.Brood,
                        Honey = appInspections.Honey,
                        BroodPattern = appInspections.BroodPattern,
                        Issues = appInspections.Issues,
                        Growth = appInspections.Growth,
                        Seasonal = appInspections.Seasonal,
                        Status = appInspections.Status,
                        Cells = appInspections.Cells,
                        SwarmStatus = appInspections.SwarmStatus,
                        Excluder = appInspections.Excluder
                    };

                    if (localInspection == null)
                    {
                        _db.TypicalInspection.Add(inspection);
                    }
                    else if (appInspections.LastModifiedDate > localInspection.LastModifiedDate)
                    {
                        _db.TypicalInspection.Remove(localInspection);
                        _db.TypicalInspection.Add(inspection);
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
                        appInspections.Weather = localInspection.Weather;
                        appInspections.Population = localInspection.Population;
                        appInspections.Mood = localInspection.Mood;
                        appInspections.Fitness = localInspection.Fitness;
                        appInspections.BroodChambers = localInspection.BroodChambers;
                        appInspections.HoneyChamber = localInspection.HoneyChamber;
                        appInspections.MouseGuard = localInspection.MouseGuard;
                        appInspections.WaspGuard = localInspection.WaspGuard;
                        appInspections.PollenCollector = localInspection.PollenCollector;
                        appInspections.HiveBottom = localInspection.HiveBottom;
                        appInspections.Vents = localInspection.Vents;
                        appInspections.Brood = localInspection.Brood;
                        appInspections.Honey = localInspection.Honey;
                        appInspections.BroodPattern = localInspection.BroodPattern;
                        appInspections.Issues = localInspection.Issues;
                        appInspections.Growth = localInspection.Growth;
                        appInspections.Seasonal = localInspection.Seasonal;
                        appInspections.Status = localInspection.Status;
                        appInspections.Cells = localInspection.Cells;
                        appInspections.SwarmStatus = localInspection.SwarmStatus;
                        appInspections.Excluder = localInspection.Excluder;
                    }
                }

                var appInspectionIds = inspections.Select(u => u.Id).ToList();
                var uniqueLocalInspection = _db.TypicalInspection.Where(u => !appInspectionIds.Contains(u.Id)).Select(u => new TypicalInspectionDto()
                {
                    Id = u.Id,
                    IsActive = u.IsActive,
                    CreatedDate = u.CreatedDate,
                    CreatedBy = u.CreatedBy,
                    LastModifiedDate = u.LastModifiedDate,
                    LastModifiedBy = u.LastModifiedBy,
                    UserId = u.UserID,
                    ColonyId = u.ColonyId,
                    Weather = u.Weather,
                    Population = u.Population,
                    Mood = u.Mood,
                    Fitness = u.Fitness,
                    BroodChambers = u.BroodChambers,
                    HoneyChamber = u.HoneyChamber,
                    MouseGuard = u.MouseGuard,
                    WaspGuard = u.WaspGuard,
                    PollenCollector = u.PollenCollector,
                    HiveBottom = u.HiveBottom,
                    Vents = u.Vents,
                    Brood = u.Brood,
                    Honey = u.Honey,
                    BroodPattern = u.BroodPattern,
                    Issues = u.Issues,
                    Growth = u.Growth,
                    Seasonal = u.Seasonal,
                    Status = u.Status,
                    Cells = u.Cells,
                    SwarmStatus = u.SwarmStatus,
                    Excluder = u.Excluder
                }).ToList();

                inspections.AddRange(uniqueLocalInspection);
                _db.SaveChanges();

                return Task.FromResult<IEnumerable<TypicalInspectionDto>>(inspections);
            }
        }
    }
}
