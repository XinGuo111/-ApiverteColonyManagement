using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Server.CQS.DTOs;
using Server.DataModels;

namespace Server.CQS.Commands.SpecialInspection
{
    public class AddSpecialInspectionCommand : IRequest<Guid>
    {
        public SpecialInspectionDto SpecialInspectionDto { get; set; }

        public class AddSpecialInspectionCommandHandler : IRequestHandler<AddSpecialInspectionCommand, Guid>
        {
            private readonly Context _db;

            public AddSpecialInspectionCommandHandler(Context db)
            {
                _db = db;
            }
            public async Task<Guid> Handle(AddSpecialInspectionCommand request, CancellationToken cancellationToken)
            {
                var inspection = new DataModels.SpecialInspection()
                {
                    Id = request.SpecialInspectionDto.Id,
                    IsActive = request.SpecialInspectionDto.IsActive,
                    UserID = request.SpecialInspectionDto.UserId,
                    ColonyId = request.SpecialInspectionDto.ColonyId,
                    Harvest = request.SpecialInspectionDto.Harvest,
                    Feeds = request.SpecialInspectionDto.Feeds,
                    Treatments = request.SpecialInspectionDto.Treatments,
                    TreatmentDetails = request.SpecialInspectionDto.TreatmentDetails,
                    Wintering = request.SpecialInspectionDto.Wintering,
                    Growth = request.SpecialInspectionDto.Growth
                };
                await _db.AddAsync(inspection, cancellationToken);
                _db.SaveChanges();
                return inspection.Id;
            }
        }
    }
}
