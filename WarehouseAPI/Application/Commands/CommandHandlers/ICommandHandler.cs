using WarehouseAPI.Application.Commands;

namespace WarehouseAPI.Application.Commands.CommandHandlers
{
    public interface ICommandHandler<in TRequest, Tresponse> where TRequest : ICommand<Tresponse>
    {
        Task<Tresponse> HandleAsync(TRequest command);
    }
}
