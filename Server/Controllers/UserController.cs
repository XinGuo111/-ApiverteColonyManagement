using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Server.CQS.Commands;
using Server.CQS.Commands.User;
using Server.CQS.DTOs;
using Server.CQS.Queries;

namespace Server.Controllers
{
    [Route("[controller]")]
    public class UserController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost, Route("AddUser")]
        public async Task<IActionResult> AddUser(LookupDto user)
        {
            var result = await Mediator.Send(new AddUserCommand()
            {
                Id = user.Id,
                Name = user.Name,
                IsActive = user.IsActive,
            });
            return Ok(result);
        }

        [HttpPost, Route("EditUser")]
        public async Task<IActionResult> EditUser(LookupDto user)
        {
            var result = await Mediator.Send(new EditUserCommand()
            {
                Id = user.Id,
                Name = user.Name,
                IsActive = user.IsActive
            });
            if (result == Guid.Empty) return NotFound();
            return Ok(result);
        }

        [HttpGet, Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await Mediator.Send(new GetUsersQuery());
            return Ok(result);
        }

        [HttpPost, Route("SyncUsers")]
        public async Task<IActionResult> SyncUsers([FromBody] List<LookupDto> users)
        {
            var result = await Mediator.Send(new SyncUsersCommand()
            {
                Users = users
            });
            return Ok(result);
        }
    }
}
