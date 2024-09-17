using MediatR;
using SuppliersManager.Shared.Wrapper;

namespace SuppliersManager.Application.Features.Suppliers.Commands
{
    public class DeleteSupplierCommand : IRequest<IResult>
    {
        public DeleteSupplierCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }

    }

    internal class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, IResult>
    {

        public DeleteSupplierCommandHandler()
        {
        }

        public async Task<IResult> Handle(DeleteSupplierCommand command, CancellationToken cancellationToken)
        {
            return await Result.SuccessAsync();
        }
    }
}
