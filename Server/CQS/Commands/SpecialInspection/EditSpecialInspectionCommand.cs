using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.CQS.DTOs;
using Server.DataModels;

namespace Server.CQS.Commands.SpecialInspection
{
    public class EditSpecialInspectionCommand : IRequest<Guid>
    {
        public SpecialInspectionDto SpecialInspectionDto { get; set; }

        public class EditSpecialInspectionCommandHandler : IRequestHandler<EditSpecialInspectionCommand, Guid>
        {
            private readonly Context _db;

            public EditSpecialInspectionCommandHandler(Context db)
            {
                _db = db;
            }
            public async Task<Guid> Handle(EditSpecialInspectionCommand request, CancellationToken cancellationToken)
            {
                var inspection = await _db.SpecialInspection.FirstOrDefaultAsync(c => c.Id == request.SpecialInspectionDto.Id, cancellationToken: cancellationToken);
                if (inspection == null) return Guid.Empty;

                inspection.Id = request.SpecialInspectionDto.Id;
                inspection.IsActive = request.SpecialInspectionDto.IsActive;
                inspection.ColonyId = request.SpecialInspectionDto.ColonyId;
                inspection.Harvest = request.SpecialInspectionDto.Harvest;
                inspection.Feeds = request.SpecialInspectionDto.Feeds;
                inspection.Treatments = request.SpecialInspectionDto.Treatments;
                inspection.TreatmentDetails = request.SpecialInspectionDto.TreatmentDetails;
                inspection.Wintering = request.SpecialInspectionDto.Wintering;
                inspection.Growth = request.SpecialInspectionDto.Growth;
                _db.SaveChanges();
                return inspection.Id;
            }
        }
    }
}
