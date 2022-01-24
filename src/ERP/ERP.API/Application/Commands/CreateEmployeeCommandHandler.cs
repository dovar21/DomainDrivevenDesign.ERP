namespace ERP.API.Application.Commands
{
    using Domain.AggregatesModel.EmployeeAggregate;
    using MediatR;
    using ERP.Infrastructure.Idempotency;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    // Regular CommandHandler
    public class CreateEmployeeCommandHandler
        : IRequestHandler<CreateEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMediator _mediator;
        private readonly ILogger<CreateEmployeeCommandHandler> _logger;

        // Using DI to inject infrastructure persistence Repositories
        public CreateEmployeeCommandHandler(IMediator mediator,
            IEmployeeRepository employeeRepository,
            ILogger<CreateEmployeeCommandHandler> logger)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(CreateEmployeeCommand message, CancellationToken cancellationToken)
        {
            var entity = new Employee(message.FirstName, message.MiddleName, message.LastName, message.DateOfBirth);
            entity.SetNationalityId(message.NationalityId);
            entity.Enable();
            _logger.LogInformation("----- Creating Employee - Employee: {@Employee}", entity);

            _employeeRepository.Add(entity);

            return await _employeeRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
