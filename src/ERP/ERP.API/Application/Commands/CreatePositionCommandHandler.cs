namespace ERP.API.Application.Commands
{
    using MediatR;
    using ERP.Infrastructure.Idempotency;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using ERP.Domain.AggregatesModel.PositionAggregate;

    // Regular CommandHandler
    public class CreatePositionCommandHandler
        : IRequestHandler<CreatePositionCommand, bool>
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMediator _mediator;
        private readonly ILogger<CreatePositionCommandHandler> _logger;

        // Using DI to inject infrastructure persistence Repositories
        public CreatePositionCommandHandler(IMediator mediator,
            IPositionRepository positionRepository,
            ILogger<CreatePositionCommandHandler> logger)
        {
            _positionRepository = positionRepository ?? throw new ArgumentNullException(nameof(positionRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(CreatePositionCommand message, CancellationToken cancellationToken)
        {
            var entity = new Position(message.Name);
            entity.Enable();
            _logger.LogInformation("----- Creating Position - Position: {@Position}", entity);

            _positionRepository.Add(entity);

            return await _positionRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
