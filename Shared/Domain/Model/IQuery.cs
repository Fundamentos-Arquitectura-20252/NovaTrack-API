using MediatR;

namespace NovaTrack.Shared.Domain.Model
{
    public interface IQuery<out TResponse> : IRequest<TResponse> { }
}
