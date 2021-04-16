using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Server.CQS.Commands;
using Server.CQS.Commands.SpecialInspection;
using Server.CQS.Commands.TypicalInspection;
using Server.CQS.DTOs;
using Server.CQS.Queries;

namespace Server.Controllers
{
    [Route("[controller]")]
    public class InspectionController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost, Route("AddTypicalInspection")]
        public async Task<IActionResult> AddTypicalInspection(TypicalInspectionDto dto)
        {
            var result = await Mediator.Send(new AddTypicalInspectionCommand()
            {
                TypicalInspectionDto = dto
            });
            return Ok(result);
        }

        [HttpPost, Route("EditTypicalInspection")]
        public async Task<IActionResult> EditTypicalInspection(TypicalInspectionDto dto)
        {
            var result = await Mediator.Send(new EditTypicalInspectionCommand()
            {
                TypicalInspectionDto = dto
            });
            return Ok(result);
        }

        [HttpGet, Route("GetTypicalInspections")]
        public async Task<IActionResult> GetTypicalInspections()
        {
            var result = await Mediator.Send(new GetTypicalInspectionQuery());
            return Ok(result);
        }

        [HttpPost, Route("SyncTypicalInspection")]
        public async Task<IActionResult> SyncTypicalInspection([FromBody] List<TypicalInspectionDto> inspections)
        {
            var result = await Mediator.Send(new SyncTypicalInspectionCommand()
            {
                Inspections = inspections
            });
            return Ok(result);
        }

        [HttpPost, Route("AddSpecialInspection")]
        public async Task<IActionResult> AddSpecialInspection(SpecialInspectionDto dto)
        {
            var result = await Mediator.Send(new AddSpecialInspectionCommand()
            {
                SpecialInspectionDto = dto
            });
            return Ok(result);
        }

        [HttpPost, Route("EditSpecialInspection")]
        public async Task<IActionResult> EditSpecialInspection(SpecialInspectionDto dto)
        {
            var result = await Mediator.Send(new EditSpecialInspectionCommand()
            {
                SpecialInspectionDto = dto
            });
            return Ok(result);
        }

        [HttpGet, Route("GetSpecialInspections")]
        public async Task<IActionResult> GetSpecialInspections()
        {
            var result = await Mediator.Send(new GetSpecialInspectionsQuery());
            return Ok(result);
        }

        [HttpPost, Route("SyncSpecialInspection")]
        public async Task<IActionResult> SyncSpecialInspection([FromBody] List<SpecialInspectionDto> inspections)
        {
            var result = await Mediator.Send(new SyncSpecialInspectionCommand()
            {
                Inspections = inspections
            });
            return Ok(result);
        }
    }
}
