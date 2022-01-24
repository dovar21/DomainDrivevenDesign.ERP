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
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IEmployeeQueries _employeeQueries;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(
            IMediator mediator,
            IEmployeeQueries employeeQueries,
            ILogger<EmployeesController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _employeeQueries = employeeQueries ?? throw new ArgumentNullException(nameof(employeeQueries));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        [Route("{id:int}")]
        [HttpGet]
        [ProducesResponseType(typeof(Employee), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetEmployeeAsync(int id)
        {
            try
            {
                var employee = await _employeeQueries.GetEmployeeAsync(id);

                return Ok(employee);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeAsync([FromBody] CreateEmployeeCommand command)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}",
                command.GetGenericTypeName(),
                nameof(command.FirstName));

            if (!await _mediator.Send(command))
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
