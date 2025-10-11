using NovaTrack.Shared.Domain.Model.Events;

namespace NovaTrack.Shared.Domain.Model
{
    public interface IAggregateRoot : IEntity
    {
        IReadOnlyCollection<DomainEvent> DomainEvents { get; }
        void AddDomainEvent(DomainEvent domainEvent);
        void RemoveDomainEvent(DomainEvent domainEvent);
        void ClearDomainEvents();
    }
}
