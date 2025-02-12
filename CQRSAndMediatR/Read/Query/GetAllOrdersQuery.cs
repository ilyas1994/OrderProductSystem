using MediatR;
using Models;

namespace CQRSAndMediatR.Read;

public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>
{
    
}