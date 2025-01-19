using WarehouseAPI.Application.Commands;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WarehouseAPI.Application.Queries.QueryHandlers
{
    public interface IQueryHandler<in TQuery, TResponse> where TQuery : IQuery
    {
        Task<TResponse> HandleAsync(TQuery query);
    }
}
