using MediatR;

namespace Default.Application.Core.Interfaces
{
    public interface ICommand : IRequest<CommandResult>, IBaseRequest
    {
    }
}
