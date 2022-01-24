namespace ERP.API.Application.Commands
{
    using MediatR;
    using ERP.Infrastructure.Idempotency;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using ERP.Domain.AggregatesModel.DepartmentAggregate;

    // Regular CommandHandler
    public class CreateDepartmentCommandHandler
        : IRequestHandler<CreateDepartmentCommand, bool>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMediator _mediator;
        private readonly ILogger<CreateDepartmentCommandHandler> _logger;

        // Using DI to inject infrastructure persistence Repositories
        public CreateDepartmentCommandHandler(IMediator mediator,
            IDepartmentRepository departmentRepository,
            ILogger<CreateDepartmentCommandHandler> logger)
        {
            _departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(CreateDepartmentCommand message, CancellationToken cancellationToken)
        {
            var entity = new Department(message.Name);
            entity.Enable();
            _logger.LogInformation("----- Creating Department - Department: {@Department}", entity);

            _departmentRepository.Add(entity);

            return await _departmentRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
