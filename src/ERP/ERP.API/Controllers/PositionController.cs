using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ERP.BuildingBlocks.EventBus.Extensions;
using ERP.API.Application.Commands;
using ERP.API.Application.Queries;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ERP.API.Controllers
{
    [Route("api/v1/[controller]")]
    //[Authorize]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPositionQueries _positionQueries;
        private readonly ILogger<PositionsController> _logger;

        public PositionsController(
            IMediator mediator,
            IPositionQueries positionQueries,
            ILogger<PositionsController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _positionQueries = positionQueries ?? throw new ArgumentNullException(nameof(positionQueries));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        [Route("{id:int}")]
        [HttpGet]
        [ProducesResponseType(typeof(Position), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetCreatePositionAsync(int id)
        {
            try
            {
                var position = await _positionQueries.GetPositionAsync(id);

                return Ok(position);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreatePositionAsync([FromBody] CreatePositionCommand command)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}",
                command.GetGenericTypeName(),
                nameof(command.Name));

            if (!await _mediator.Send(command))
            {
                return BadRequest();
            }

            return Ok();
        }
        [Route("Positions")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Position>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Position>>> GetPositionsAsync()
        {
            var cardTypes = await _positionQueries.GetPositionsAsync();

            return Ok(cardTypes);
        }

    }
}
