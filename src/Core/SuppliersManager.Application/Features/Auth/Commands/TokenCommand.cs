using MediatR;
using SuppliersManager.Application.Interfaces.Services;
using SuppliersManager.Shared.Wrapper;

namespace SuppliersManager.Application.Features.Auth.Commands
{
    public class TokenCommand : IRequest<IResult<TokenCommandResponse>>
    {
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;

    }

    internal class TokenCommandHandler : IRequestHandler<TokenCommand, IResult<TokenCommandResponse>>
    {
        private readonly IAuthService _authService;

        public TokenCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<IResult<TokenCommandResponse>> Handle(TokenCommand command, CancellationToken cancellationToken)
        {
           return await _authService.LoginJWT(command);
        }
    }

    public class TokenCommandResponse
    {
        public string AccessToken { get; set; } = default!;
    }
}
