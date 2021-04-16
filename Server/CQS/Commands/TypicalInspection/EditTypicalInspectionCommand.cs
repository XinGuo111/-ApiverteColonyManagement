using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.CQS.DTOs;
using Server.DataModels;

namespace Server.CQS.Commands.TypicalInspection
{
    public class EditTypicalInspectionCommand : IRequest<Guid>
    {
        public TypicalInspectionDto TypicalInspectionDto { get; set; }

        public class EditTypicalInspectionCommandHandler : IRequestHandler<EditTypicalInspectionCommand, Guid>
        {
            private readonly Context _db;

            public EditTypicalInspectionCommandHandler(Context db)
            {
                _db = db;
            }
            public async Task<Guid> Handle(EditTypicalInspectionCommand request, CancellationToken cancellationToken)
            {
                var inspection = await _db.TypicalInspection.FirstOrDefaultAsync(c => c.Id == request.TypicalInspectionDto.Id, cancellationToken: cancellationToken);
                if (inspection == null) return Guid.Empty;

                inspection.Id = request.TypicalInspectionDto.Id;
                inspection.IsActive = request.TypicalInspectionDto.IsActive;
                inspection.ColonyId = request.TypicalInspectionDto.ColonyId;
                inspection.Weather = request.TypicalInspectionDto.Weather;
                inspection.Population = request.TypicalInspectionDto.Population;
                inspection.Mood = request.TypicalInspectionDto.Mood;
                inspection.Fitness = request.TypicalInspectionDto.Fitness;
                inspection.BroodChambers = request.TypicalInspectionDto.BroodChambers;
                inspection.HoneyChamber = request.TypicalInspectionDto.HoneyChamber;
                inspection.MouseGuard = request.TypicalInspectionDto.MouseGuard;
                inspection.WaspGuard = request.TypicalInspectionDto.WaspGuard;
                inspection.PollenCollector = request.TypicalInspectionDto.PollenCollector;
                inspection.HiveBottom = request.TypicalInspectionDto.HiveBottom;
                inspection.Vents = request.TypicalInspectionDto.Vents;
                inspection.Brood = request.TypicalInspectionDto.Brood;
                inspection.Honey = request.TypicalInspectionDto.Honey;
                inspection.BroodPattern = request.TypicalInspectionDto.BroodPattern;
                inspection.Issues = request.TypicalInspectionDto.Issues;
                inspection.Growth = request.TypicalInspectionDto.Growth;
                inspection.Seasonal = request.TypicalInspectionDto.Seasonal;
                inspection.Status = request.TypicalInspectionDto.Status;
                inspection.Cells = request.TypicalInspectionDto.Cells;
                inspection.SwarmStatus = request.TypicalInspectionDto.SwarmStatus;
                inspection.Excluder = request.TypicalInspectionDto.Excluder;
                _db.SaveChanges();
                return inspection.Id;
            }
        }
    }
}
