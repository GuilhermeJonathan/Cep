using MediatR;

namespace Cep.Application.Core.Interfaces
{
    public interface ICommand : IRequest<CommandResult>, IBaseRequest
    {
    }
}
