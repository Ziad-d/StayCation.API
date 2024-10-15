using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Common.Helpers;
using StayCation.API.VerticalSlicing.Data.Models;
using MediatR;

namespace StayCation.API.VerticalSlicing.Features.OrderItems.AddOrderItem.Commands
{
    public record AddOrderItemCommand(int OrderId, int RecipeId, int Quantity) : IRequest<ResultDTO>;

    public class AddOrderItemCommandHandler : BaseRequestHandler<OrderItem, AddOrderItemCommand, ResultDTO>
    {
        public AddOrderItemCommandHandler(RequestParameters<OrderItem> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<ResultDTO> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
        {
            var OrderItem = request.MapOne<OrderItem>();
            OrderItem = await _repository.AddAsync(OrderItem);

            return ResultDTO.Success(OrderItem);
        }
    }
}
