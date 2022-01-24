namespace ERP.API.Application.Commands
{
    using MediatR;
    using ERP.Infrastructure.Idempotency;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using ERP.Domain.AggregatesModel.GenderAggregate;

    // Regular CommandHandler
    public class CreateGenderCommandHandler
        : IRequestHandler<CreateGenderCommand, bool>
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IMediator _mediator;
        private readonly ILogger<CreateGenderCommandHandler> _logger;

        // Using DI to inject infrastructure persistence Repositories
        public CreateGenderCommandHandler(IMediator mediator,
            IGenderRepository genderRepository,
            ILogger<CreateGenderCommandHandler> logger)
        {
            _genderRepository = genderRepository ?? throw new ArgumentNullException(nameof(genderRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(CreateGenderCommand message, CancellationToken cancellationToken)
        {
            var entity = new Gender(message.Name);
            entity.Enable();
            _logger.LogInformation("----- Creating Gender - Gender: {@Gender}", entity);

            _genderRepository.Add(entity);

            return await _genderRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
