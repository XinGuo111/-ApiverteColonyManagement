using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.DataModels;

namespace Server.CQS.Commands.Host
{
    public class EditHostCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public class EditHostCommandHandler : IRequestHandler<EditHostCommand, Guid>
        {
            private readonly Context _db;

            public EditHostCommandHandler(Context db)
            {
                _db = db;
            }
            public async Task<Guid> Handle(EditHostCommand request, CancellationToken cancellationToken)
            {
                var area = await _db.Host.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken: cancellationToken);
                if (area == null) return Guid.Empty;

                area.Name = request.Name;
                area.IsActive = request.IsActive;
                _db.SaveChanges();

                return area.Id;
            }
        }
    }
}
