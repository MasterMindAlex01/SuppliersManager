using MediatR;
using SuppliersManager.Shared.Wrapper;
using System.ComponentModel.DataAnnotations;

namespace SuppliersManager.Application.Features.Suppliers.Commands
{
    public class CreateSupplierCommand : IRequest<IResult>
    {
        [Required]
        public string TIN { get; set; } = null!;
        [Required]
        public string RegisteredName { get; set; } = null!;
        [Required]
        public string Address { get; set; } = null!;
        [Required]
        public string City { get; set; } = null!;
        [Required]
        public string State { get; set; } = null!;
        [Required,EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public string CreateByContact { get; set; } = null!;
        [Required, EmailAddress]
        public string EmailContact { get; set; } = null!;

    }

    internal class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, IResult>
    {

        public CreateSupplierCommandHandler()
        {
        }

        public async Task<IResult> Handle(CreateSupplierCommand command, CancellationToken cancellationToken)
        {
            return await Result.SuccessAsync();
        }
    }
}
