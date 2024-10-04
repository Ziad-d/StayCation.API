using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using StayCation.API.VerticalSlicing.Common.Constants;
using StayCation.API.VerticalSlicing.Common.Enums;
using StayCation.API.VerticalSlicing.Features.Admin.AssignFeaturesToRole.Queries;
using StayCation.VerticalSlicing.Features.Admin.AssignRolesToUser.Queries;

namespace StayCation.API.VerticalSlicing.Common.Attributes
{
    public class CustomizedAuthorize : ActionFilterAttribute
    {
        private readonly Feature _feature;
        private readonly IMediator _mediator;

        public CustomizedAuthorize(Feature feature, IMediator mediator)
        {
            _feature = feature;
            _mediator = mediator;
        }

        public override async void OnActionExecuting(ActionExecutingContext context)
        {
            var loggedUser = context.HttpContext.User;

            var userIdClaim = loggedUser.FindFirst(CustomClaimTypes.Id)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
            {
                throw new UnauthorizedAccessException("User is not authenticated.");
            }

            int userId = int.Parse(userIdClaim);

            var roleIDs = await _mediator.Send(new GetRolesByUserIdQuery(userId));

            if (roleIDs == null || !roleIDs.Any())
            {
                throw new UnauthorizedAccessException("No roles found for the user.");
            }

            bool hasAccess = false;

            foreach (var roleID in roleIDs)
            {
                var query = new CheckRoleFeatureAccessQuery(roleID, _feature);
                hasAccess = await _mediator.Send(query);

                if (hasAccess)
                {
                    break;
                }
            }

            if (!hasAccess)
            {
                throw new UnauthorizedAccessException("User does not have access to this feature.");
            }

            base.OnActionExecuting(context);
        }
    }
}
