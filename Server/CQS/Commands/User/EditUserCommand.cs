using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.DataModels;

namespace Server.CQS.Commands.User
{
    public class EditUserCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string LastModifiedBy { get; set; }
        public long LastModifiedDate { get; set; }

        public class EditUserCommandHandler : IRequestHandler<EditUserCommand, Guid>
        {
            private readonly Context _db;

            public EditUserCommandHandler(Context db)
            {
                _db = db;
            }
            public async Task<Guid> Handle(EditUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _db.User.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken: cancellationToken);
                if (user == null) return Guid.Empty;

                user.Name = request.Name;
                user.IsActive = request.IsActive;
                user.LastModifiedDate = request.LastModifiedDate;
                user.LastModifiedBy = request.LastModifiedBy;

                _db.SaveChanges();

                return user.Id;
            }
        }
    }
}
