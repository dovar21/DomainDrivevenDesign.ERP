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
    public class NationalitiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly INationalityQueries _nationalityQueries;
        private readonly ILogger<NationalitiesController> _logger;

        public NationalitiesController(
            IMediator mediator,
            INationalityQueries nationalityQueries,
            ILogger<NationalitiesController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _nationalityQueries = nationalityQueries ?? throw new ArgumentNullException(nameof(nationalityQueries));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        [Route("{id:int}")]
        [HttpGet]
        [ProducesResponseType(typeof(Nationality), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetCreateNationalityAsync(int id)
        {
            try
            {
                var nationality = await _nationalityQueries.GetNationalityAsync(id);

                return Ok(nationality);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateNationalityAsync([FromBody] CreateNationalityCommand command)
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
        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Nationality>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Nationality>>> GetNationalitiesAsync()
        {
            var cardTypes = await _nationalityQueries.GetNationalitiesAsync();

            return Ok(cardTypes);
        }

    }
}
