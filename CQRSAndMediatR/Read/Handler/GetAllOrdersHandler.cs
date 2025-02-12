using MediatR;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository;

namespace CQRSAndMediatR.Read.Handler;
/// <summary>
/// Получение всех товаров
/// </summary>
public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>
{
    private readonly IBaseLogic _baseLogic;

    public GetAllOrdersHandler(IBaseLogic baseLogic)
    {
        _baseLogic = baseLogic;
    }


    public async Task<IEnumerable<Models.Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
       return await _baseLogic.BaseRepo()
            .GetQueryable<Order>()
            .Where(x => x.DeleteDate == null)
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);
    }
}