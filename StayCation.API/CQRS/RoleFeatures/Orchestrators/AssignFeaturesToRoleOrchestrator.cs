using MediatR;
using StayCation.API.CQRS.Roles.Queries;
using StayCation.API.DTOs;
using StayCation.API.DTOs.RoleFeatureDTOs;
using StayCation.API.Enums;
using StayCation.API.Exceptions;
using StayCation.API.Models;
using StayCation.API.Repositories;

namespace StayCation.API.CQRS.RoleFeatures.Orchestrators
{
    public record AssignFeaturesToRoleOrchestrator(FeaturesToRoleDTO FeaturesToRoleDTO) : IRequest<bool>;

    public class AssignFeaturesToRoleOrchestratorHandler : IRequestHandler<AssignFeaturesToRoleOrchestrator, bool>
    {
        private readonly IRepository<RoleFeature> _repository;
        private readonly IMediator _mediator;

        public AssignFeaturesToRoleOrchestratorHandler(IRepository<RoleFeature> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(AssignFeaturesToRoleOrchestrator request, CancellationToken cancellationToken)
        {
            if (request == null || request.FeaturesToRoleDTO == null || !request.FeaturesToRoleDTO.Features.Any())
            {
                throw new BusinessException(ErrorCode.InvalidData, "Invalid inputs");
            }

            var role = await _mediator.Send(new GetRoleByIdQuery(request.FeaturesToRoleDTO.RoleId));
            //var role = await _repository.GetByIdAsync(request.addFeaturesToRuleDTO.RoleId);
            if (role == null)
            {
                throw new BusinessException(ErrorCode.InvalidRoleID, "Invalid RoleID!");
            }

            foreach (var feature in request.FeaturesToRoleDTO.Features)
            {
                var existingRoleFeature = await _repository.First(
                    rf => rf.RoleID == request.FeaturesToRoleDTO.RoleId && rf.Feature == feature
                );

                if (existingRoleFeature == null)
                {
                    var roleFeature = new RoleFeature
                    {
                        RoleID = request.FeaturesToRoleDTO.RoleId,
                        Feature = feature
                    };

                    await _repository.AddAsync(roleFeature);
                }
            }

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
