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
    public class GendersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IGenderQueries _genderQueries;
        private readonly ILogger<GendersController> _logger;

        public GendersController(
            IMediator mediator,
            IGenderQueries genderQueries,
            ILogger<GendersController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _genderQueries = genderQueries ?? throw new ArgumentNullException(nameof(genderQueries));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        [Route("{id:int}")]
        [HttpGet]
        [ProducesResponseType(typeof(Gender), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetCreateGenderAsync(int id)
        {
            try
            {
                var employee = await _genderQueries.GetGenderAsync(id);

                return Ok(employee);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateGenderAsync([FromBody] CreateGenderCommand command)
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
        [Route("Genders")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Gender>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Gender>>> GetGendersAsync()
        {
            var cardTypes = await _genderQueries.GetGendersAsync();

            return Ok(cardTypes);
        }

    }
}
