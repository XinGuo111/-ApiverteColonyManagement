using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Server.CQS.DTOs;
using Server.DataModels;

namespace Server.CQS.Commands.Colony
{
    public class AddColonyCommand : IRequest<Guid>
    {
        public ColonyDto ColonyDto { get; set; }
        public class AddColonyCommandHandler : IRequestHandler<AddColonyCommand, Guid>
        {
            private readonly Context _db;

            public AddColonyCommandHandler(Context db)
            {
                _db = db;
            }
            public async Task<Guid> Handle(AddColonyCommand request, CancellationToken cancellationToken)
            {
                var colony = new DataModels.Colony.Colony()
                {
                    Id = request.ColonyDto.Id,
                    IsActive = request.ColonyDto.IsActive,
                    HostId = request.ColonyDto.HostId,
                    AreaId = request.ColonyDto.AreaId,
                    HiveNumber = request.ColonyDto.HiveNumber,
                    ColonyNumber = request.ColonyDto.ColonyNumber,
                    ColonySource = request.ColonyDto.ColonySource,
                    QueenType = request.ColonyDto.QueenType,
                    Markings = request.ColonyDto.Markings,
                    GeneticBreed = request.ColonyDto.GeneticBreed,
                    InstallationType = request.ColonyDto.InstallationType,
                    AdditionalInfo = request.ColonyDto.AdditionalInfo,
                    InstallDate = request.ColonyDto.InstallDate,
                    HiveType = request.ColonyDto.HiveType,
                    BroodChamberType = request.ColonyDto.BroodChamberType,
                    QueenExclude = request.ColonyDto.QueenExclude
                };
                await _db.AddAsync(colony, cancellationToken);
                _db.SaveChanges();
                return colony.Id;
            }
        }

    }
}
