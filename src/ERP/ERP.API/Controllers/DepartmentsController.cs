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
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDepartmentQueries _departmentQueries;
        private readonly ILogger<DepartmentsController> _logger;

        public DepartmentsController(
            IMediator mediator,
            IDepartmentQueries departmentQueries,
            ILogger<DepartmentsController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _departmentQueries = departmentQueries ?? throw new ArgumentNullException(nameof(departmentQueries));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        [Route("{id:int}")]
        [HttpGet]
        [ProducesResponseType(typeof(Department), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetCreateDepartmentAsync(int id)
        {
            try
            {
                var department = await _departmentQueries.GetDepartmentAsync(id);

                return Ok(department);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateDepartmentAsync([FromBody] CreateDepartmentCommand command)
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
        [Route("Departments")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Department>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartmentsAsync()
        {
            var cardTypes = await _departmentQueries.GetDepartmentsAsync();

            return Ok(cardTypes);
        }

    }
}
