using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Server.DataModels;

namespace Server.CQS.Commands.Area
{
    public class AddAreaCommand : IRequest<Guid>
    {
        public Guid Id;
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public class AddAreaCommandHandler : IRequestHandler<AddAreaCommand, Guid>
        {
            private readonly Context _db;

            public AddAreaCommandHandler(Context db)
            {
                _db = db;
            }
            public async Task<Guid> Handle(AddAreaCommand request, CancellationToken cancellationToken)
            {
                var area = new DataModels.Colony.Area()
                {
                    Id = request.Id,
                    Name = request.Name,
                    IsActive = request.IsActive
                };
                await _db.Area.AddAsync(area, cancellationToken);
                _db.SaveChanges();
                return area.Id;
            }
        }
    }
}
