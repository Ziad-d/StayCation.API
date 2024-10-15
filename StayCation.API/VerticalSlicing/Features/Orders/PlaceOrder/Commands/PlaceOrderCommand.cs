using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Common.Helpers;
using StayCation.API.VerticalSlicing.Data.Models;
using MassTransit;
using MediatR;

namespace StayCation.API.VerticalSlicing.Features.Orders.PlaceOrder.Commands
{
    public record PlaceOrderCommand(int UserId, List<PlaceOrderItemDTO> OrderItems) : IRequest<ResultDTO>;
    public class PlaceOrderCommandHandler : BaseRequestHandler<Order, PlaceOrderCommand, ResultDTO>
    {
        public PlaceOrderCommandHandler(RequestParameters<Order> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<ResultDTO> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            var order = request.MapOne<Order>();

            order = await _repository.AddAsync(order);
            await _repository.SaveChangesAsync();

            return ResultDTO.Success(order);
        }
    }
}
