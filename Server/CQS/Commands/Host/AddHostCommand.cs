using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Server.DataModels;

namespace Server.CQS.Commands.Host
{
    public class AddHostCommand : IRequest<Guid>
    {
        public Guid Id;
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public class AddHostCommandHandler : IRequestHandler<AddHostCommand, Guid>
        {
            private readonly Context _db;

            public AddHostCommandHandler(Context db)
            {
                _db = db;
            }
            public async Task<Guid> Handle(AddHostCommand request, CancellationToken cancellationToken)
            {
                var host = new DataModels.Colony.Host()
                {
                    Id = request.Id,
                    Name = request.Name,
                    IsActive = request.IsActive
                };
                await _db.Host.AddAsync(host, cancellationToken);
                _db.SaveChanges();
                return host.Id;
            }
        }
    }
}
