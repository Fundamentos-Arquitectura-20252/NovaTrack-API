using MediatR;

namespace NovaTrack.Shared.Domain.Model
{
    public interface ICommand : IRequest<bool> { }
    public interface ICommand<out TResponse> : IRequest<TResponse> { }
}