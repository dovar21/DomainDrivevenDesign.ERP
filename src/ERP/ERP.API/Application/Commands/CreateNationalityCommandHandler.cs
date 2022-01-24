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
    public class CreateNationalityCommandHandler
        : IRequestHandler<CreateNationalityCommand, bool>
    {
        private readonly INationalityRepository _nationalityRepository;
        private readonly IMediator _mediator;
        private readonly ILogger<CreateNationalityCommandHandler> _logger;

        // Using DI to inject infrastructure persistence Repositories
        public CreateNationalityCommandHandler(IMediator mediator,
            INationalityRepository nationalityRepository,
            ILogger<CreateNationalityCommandHandler> logger)
        {
            _nationalityRepository = nationalityRepository ?? throw new ArgumentNullException(nameof(nationalityRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(CreateNationalityCommand message, CancellationToken cancellationToken)
        {
            var entity = new Nationality(message.Name);
            entity.Enable();
            _logger.LogInformation("----- Creating Nationality - Nationality: {@Nationality}", entity);

            _nationalityRepository.Add(entity);

            return await _nationalityRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
