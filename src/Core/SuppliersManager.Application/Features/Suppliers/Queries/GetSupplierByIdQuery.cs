using MediatR;
using SuppliersManager.Shared.Wrapper;

namespace SuppliersManager.Application.Features.Suppliers.Queries
{
    public class GetSupplierByIdQuery : IRequest<IResult>
    {
        public GetSupplierByIdQuery(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }

    internal class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, IResult>
    {
        public GetSupplierByIdQueryHandler()
        {

        }

        public async Task<IResult> Handle(GetSupplierByIdQuery query, CancellationToken cancellationToken)
        {
            return await Result.SuccessAsync();
        }
    }
}
