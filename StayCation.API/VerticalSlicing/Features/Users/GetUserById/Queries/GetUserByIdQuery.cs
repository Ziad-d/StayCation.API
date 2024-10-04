using MediatR;
using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Common.Helpers;
using StayCation.API.VerticalSlicing.Data.Models;
using StayCation.API.VerticalSlicing.Features.Users.Register;


namespace StayCation.API.VerticalSlicing.Features.Users.GetUserById.Queries
{
    public record GetUserByIdQuery(int id) : IRequest<ResultDTO>;
    public class GetUserByIdQueryHandler : BaseRequestHandler<User, GetUserByIdQuery, ResultDTO>
    {
        public GetUserByIdQueryHandler(RequestParameters<User> requestParameters)
                                    : base(requestParameters)
        {
        }

        public override async Task<ResultDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return ResultDTO.Failure("Invalid UserID!");
            }
            var user = await _repository.GetByIDAsync(request.id);
            var mappedUser = user.MapOne<UserRegisterDTO>();
            return ResultDTO.Success(mappedUser, "User has been retrieved successfully!");
        }
    }
}
