using WarehouseAPIv2.Application.Commands;

namespace WarehouseAPIv2.Application.Commands.CommandHandlers
{
    public interface ICommandHandler<in TRequest, Tresponse> where TRequest : ICommand<Tresponse>
    {
        Task<Tresponse> HandleAsync(TRequest command);
    }
}
