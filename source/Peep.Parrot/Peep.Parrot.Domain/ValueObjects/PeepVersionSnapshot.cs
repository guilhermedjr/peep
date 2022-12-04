namespace Peep.Parrot.Domain.ValueObjects;

public record PeepVersionSnapshot(Guid PeepId, PeepContent PeepContent, DateOnly SnapshotDate, TimeOnly SnapshotTime,
        Dictionary<ApplicationUser, DateTime> Likes, IReadOnlyCollection<Entities.Peep> Replies, IReadOnlyCollection<Entities.Peep> Quotes, Dictionary<ApplicationUser, DateTime> Rps);