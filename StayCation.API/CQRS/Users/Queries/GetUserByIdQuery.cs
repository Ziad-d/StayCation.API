using MediatR;
using StayCation.API.DTOs;
using StayCation.API.DTOs.UserDTOs;
using StayCation.API.Helpers;
using StayCation.API.Models;
using StayCation.API.Repositories;

namespace StayCation.API.CQRS.Users.Queries
{
    public record GetUserByIdQuery(int id) : IRequest<ResultDTO>;
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ResultDTO>
    {
        private readonly IRepository<User> _repository;

        public GetUserByIdQueryHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<ResultDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return ResultDTO.Failure("Invalid UserID!");
            }
            var user = await _repository.GetByIDAsync(request.id);
            var mappedUser = user.MapOne<UserReturnDTO>();
            return ResultDTO.Success(mappedUser, "User has been retrieved successfully!");
        }
    }
}
