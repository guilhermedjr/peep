using Peep.Parrot.Domain.Enums;
namespace Peep.Parrot.Application.Dtos;

public record ChangePeepReplyRestrictionDto
{
    public Guid PeepId { get; init; }
    public EPeepReplyRestriction ReplyRestriction { get; init; }
}