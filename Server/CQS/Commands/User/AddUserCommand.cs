using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Server.DataModels;

namespace Server.CQS.Commands.User
{
    public class AddUserCommand : IRequest<Guid>
    {
        public Guid Id;
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;

        public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Guid>
        {
            private readonly Context _db;

            public AddUserCommandHandler(Context db)
            {
                _db = db;
            }
            public Task<Guid> Handle(AddUserCommand request, CancellationToken cancellationToken)
            {
                var user = new DataModels.User()
                {
                    Id = request.Id,
                    Name = request.Name,
                    IsActive = request.IsActive
                };
                _db.User.Add(user);
                _db.SaveChanges();
                return Task.FromResult(user.Id);
            }
        }
    }
}
