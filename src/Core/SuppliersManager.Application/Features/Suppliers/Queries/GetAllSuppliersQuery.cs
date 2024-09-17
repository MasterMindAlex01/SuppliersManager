using MediatR;
using SuppliersManager.Shared.Wrapper;

namespace SuppliersManager.Application.Features.Suppliers.Queries
{
    public class GetAllSuppliersQuery : IRequest<IResult>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    internal class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery,IResult>
    {
        public GetAllSuppliersQueryHandler()
        {

        }

        public async Task<IResult> Handle(GetAllSuppliersQuery query, CancellationToken cancellationToken)
        {
            return await Result.SuccessAsync();
        }
    }
}
