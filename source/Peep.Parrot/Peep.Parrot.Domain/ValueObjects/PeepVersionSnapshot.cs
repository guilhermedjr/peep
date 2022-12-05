namespace Peep.Parrot.Domain.ValueObjects;

public record PeepVersionSnapshot(Guid PeepId, PeepContent PeepContent, DateOnly SnapshotDate, TimeOnly SnapshotTime,
        Dictionary<Guid, DateTime> Likes, IReadOnlyCollection<Entities.Peep> Replies, IReadOnlyCollection<Entities.Peep> Quotes, Dictionary<Guid, DateTime> Rps);