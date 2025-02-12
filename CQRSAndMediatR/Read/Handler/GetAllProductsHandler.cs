using MediatR;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository;

namespace CQRSAndMediatR.Read.Handler;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<DicProducts>>
{
    private readonly IBaseLogic _baseLogic;

    public GetAllProductsHandler(IBaseLogic baseLogic)
    {
        _baseLogic = baseLogic;
    }

    public async Task<IEnumerable<DicProducts>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await _baseLogic.BaseRepo()
            .GetQueryable<DicProducts>()
            .Where(x => x.DeleteDate == null)
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
