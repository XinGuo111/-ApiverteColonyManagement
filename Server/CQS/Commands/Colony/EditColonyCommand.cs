using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.CQS.DTOs;
using Server.DataModels;

namespace Server.CQS.Commands.Colony
{
    public class EditColonyCommand : IRequest<Guid>
    {
        public ColonyDto ColonyDto { get; set; }
        public class EditColonyCommandHandler : IRequestHandler<EditColonyCommand, Guid>
        {
            private readonly Context _db;

            public EditColonyCommandHandler(Context db)
            {
                _db = db;
            }
            public async Task<Guid> Handle(EditColonyCommand request, CancellationToken cancellationToken)
            {
                var colony = await _db.Colony.FirstOrDefaultAsync(c => c.Id == request.ColonyDto.Id, cancellationToken: cancellationToken);

                if (colony == null) return Guid.Empty;

                colony.Id = request.ColonyDto.Id;
                colony.IsActive = request.ColonyDto.IsActive;
                colony.HostId = request.ColonyDto.HostId;
                colony.AreaId = request.ColonyDto.AreaId;
                colony.HiveNumber = request.ColonyDto.HiveNumber;
                colony.ColonyNumber = request.ColonyDto.ColonyNumber;
                colony.ColonySource = request.ColonyDto.ColonySource;
                colony.QueenType = request.ColonyDto.QueenType;
                colony.GeneticBreed = request.ColonyDto.GeneticBreed;
                colony.InstallationType = request.ColonyDto.InstallationType;
                colony.AdditionalInfo = request.ColonyDto.AdditionalInfo;
                colony.InstallDate = request.ColonyDto.InstallDate;
                colony.HiveType = request.ColonyDto.HiveType;
                colony.BroodChamberType = request.ColonyDto.BroodChamberType;
                colony.QueenExclude = request.ColonyDto.QueenExclude;
                _db.SaveChanges();
                return colony.Id;
            }
        }
    }
}
