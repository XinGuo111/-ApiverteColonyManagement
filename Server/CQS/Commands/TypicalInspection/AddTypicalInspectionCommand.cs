using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Server.CQS.DTOs;
using Server.DataModels;

namespace Server.CQS.Commands.TypicalInspection
{
    public class AddTypicalInspectionCommand : IRequest<Guid>
    {
        public TypicalInspectionDto TypicalInspectionDto { get; set; }

        public class AddTypicalInspectionCommandHandler : IRequestHandler<AddTypicalInspectionCommand, Guid>
        {
            private readonly Context _db;

            public AddTypicalInspectionCommandHandler(Context db)
            {
                _db = db;
            }
            public async Task<Guid> Handle(AddTypicalInspectionCommand request, CancellationToken cancellationToken)
            {
                var inspection = new DataModels.TypicalInspection()
                {
                    Id = request.TypicalInspectionDto.Id,
                    IsActive = request.TypicalInspectionDto.IsActive,
                    UserID = request.TypicalInspectionDto.UserId,
                    ColonyId = request.TypicalInspectionDto.ColonyId,
                    Weather = request.TypicalInspectionDto.Weather,
                    Population = request.TypicalInspectionDto.Population,
                    Mood = request.TypicalInspectionDto.Mood,
                    Fitness = request.TypicalInspectionDto.Fitness,
                    BroodChambers = request.TypicalInspectionDto.BroodChambers,
                    HoneyChamber = request.TypicalInspectionDto.HoneyChamber,
                    MouseGuard = request.TypicalInspectionDto.MouseGuard,
                    WaspGuard = request.TypicalInspectionDto.WaspGuard,
                    PollenCollector = request.TypicalInspectionDto.PollenCollector,
                    HiveBottom = request.TypicalInspectionDto.HiveBottom,
                    Vents = request.TypicalInspectionDto.Vents,
                    Brood = request.TypicalInspectionDto.Brood,
                    Honey = request.TypicalInspectionDto.Honey,
                    BroodPattern = request.TypicalInspectionDto.BroodPattern,
                    Issues = request.TypicalInspectionDto.Issues,
                    Growth = request.TypicalInspectionDto.Growth,
                    Seasonal = request.TypicalInspectionDto.Seasonal,
                    Status = request.TypicalInspectionDto.Status,
                    Cells = request.TypicalInspectionDto.Cells,
                    SwarmStatus = request.TypicalInspectionDto.SwarmStatus,
                    Excluder = request.TypicalInspectionDto.Excluder
                };

                await _db.AddAsync(inspection, cancellationToken);
                _db.SaveChanges();
                return inspection.Id;
            }
        }
    }
}
