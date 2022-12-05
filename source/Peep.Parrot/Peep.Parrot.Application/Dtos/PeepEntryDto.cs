using Peep.Parrot.Domain.Enums;
namespace Peep.Parrot.Application.Dtos;

public record PeepEntryDto
{
    public Guid UserId { get; init; }
    public EPeepViewRestriction ViewRestriction { get; init; }
    public EPeepReplyRestriction ReplyRestriction { get; init; }

    public Guid? QuotedPeepId { get; init; } = null;
    public Guid? RepliedPeepId { get; init; } = null;

    public PeepContentEntryDto PeepContentEntryDto { get; init; }

    public DateOnly? PublicationDate { get; init; } = null;
    public TimeOnly? PublicationTime { get; init; } = null; 
}
