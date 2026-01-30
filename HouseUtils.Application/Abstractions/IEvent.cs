namespace HouseUtils.Application.Abstractions;

public interface IEvent
{
   Guid EventId { get; }
}