using WarehouseAPIv2.Comman.Dtos;

namespace WarehouseAPIv2.Application.Commands
{
    public class UpdateProductActivatedCommand : ICommand<bool>
    {
        public RequestProductActive RequestProductActive { get; }

        public UpdateProductActivatedCommand(RequestProductActive requestProductActive)
        {
            this.RequestProductActive = requestProductActive;
        }
    }
}
