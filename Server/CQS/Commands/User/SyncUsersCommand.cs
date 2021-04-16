using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Server.CQS.DTOs;
using Server.DataModels;

namespace Server.CQS.Commands.User
{
    public class SyncUsersCommand : IRequest<IEnumerable<LookupDto>>
    {
        public List<LookupDto> Users { get; set; }

        public class SyncUsersCommandHandler : IRequestHandler<SyncUsersCommand, IEnumerable<LookupDto>>
        {
            private readonly Context _db;

            public SyncUsersCommandHandler(Context db)
            {
                _db = db;
            }
            public Task<IEnumerable<LookupDto>> Handle(SyncUsersCommand request, CancellationToken cancellationToken)
            {
                var users = request.Users ?? new List<LookupDto>();
                foreach (var appUser in users)
                {
                    var localUser = _db.User.FirstOrDefault(u => u.Id == appUser.Id);
                    DataModels.User user = new DataModels.User()
                    {
                        Id = appUser.Id,
                        Name = appUser.Name,
                        IsActive = appUser.IsActive,
                        CreatedDate = appUser.CreatedDate,
                        CreatedBy = appUser.CreatedBy,
                        LastModifiedDate = appUser.LastModifiedDate,
                        LastModifiedBy = appUser.LastModifiedBy
                    };

                    if (localUser == null)
                    {
                        //if user doesn't exist in database, insert it
                        _db.User.Add(user);
                    }
                    else if (appUser.LastModifiedDate > localUser.LastModifiedDate)
                    {
                        //if the app user is newer, remove the old user and add the new to db
                        _db.User.Remove(localUser);
                        _db.User.Add(user);
                    }
                    else
                    {
                        appUser.Name = localUser.Name;
                        appUser.IsActive = localUser.IsActive;
                        appUser.CreatedDate = localUser.CreatedDate;
                        appUser.CreatedBy = localUser.CreatedBy;
                        appUser.LastModifiedDate = localUser.LastModifiedDate;
                        appUser.LastModifiedBy = localUser.LastModifiedBy;
                    }
                }

                var appUserIDs = users.Select(u => u.Id).ToList();
                var uniqueLocalUsers = _db.User.Where(u => !appUserIDs.Contains(u.Id)).Select(u => new LookupDto()
                {
                    Id = u.Id,
                    Name = u.Name,
                    IsActive = u.IsActive,
                    CreatedDate = u.CreatedDate,
                    CreatedBy = u.CreatedBy,
                    LastModifiedDate = u.LastModifiedDate,
                    LastModifiedBy = u.LastModifiedBy
                }).ToList();

                users.AddRange(uniqueLocalUsers);
                _db.SaveChanges();

                return Task.FromResult<IEnumerable<LookupDto>>(users);
            }
        }
    }
}
