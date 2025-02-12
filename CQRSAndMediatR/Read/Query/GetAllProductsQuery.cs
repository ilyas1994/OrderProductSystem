using MediatR;
using Models;

namespace CQRSAndMediatR.Read;

public class GetAllProductsQuery : IRequest<IEnumerable<DicProducts>>
{
    
}