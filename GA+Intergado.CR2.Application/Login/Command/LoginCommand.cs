using ErrorOr;
using GA_Intergado.CR2.App.ServerIntegration.DTOs;
using MediatR;

namespace GA_Intergado.CR2.App.Login.Command
{
    public record LoginCommand(string Login, string Password) : IRequest<ErrorOr<Success>>;
}
