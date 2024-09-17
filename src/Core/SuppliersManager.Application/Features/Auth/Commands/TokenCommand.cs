using MediatR;
using SuppliersManager.Application.Interfaces.Services;

namespace SuppliersManager.Application.Features.Auth.Commands
{
    public class TokenCommand : IRequest<TokenCommandResponse>
    {
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;

    }

    internal class TokenCommandHandler : IRequestHandler<TokenCommand, TokenCommandResponse>
    {
        private readonly IAuthService _authService;

        public TokenCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<TokenCommandResponse> Handle(TokenCommand command, CancellationToken cancellationToken)
        {
           var result = await _authService.LoginJWT(command);
            if (!result.Succeeded)
            {
                return null!;
            }
            return result.Data;
        }
    }

    public class TokenCommandResponse
    {
        public string AccessToken { get; set; } = default!;
    }
}
