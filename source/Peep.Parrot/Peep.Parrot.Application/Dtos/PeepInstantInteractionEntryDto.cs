using Peep.Parrot.Domain.Enums;
namespace Peep.Parrot.Application.Dtos;

public record PeepInstantInteractionEntryDto
{
    public Guid UserId { get; init; }
    public Guid PeepId { get; init; }
    public EPeepInstantInteractionType InteractionType { get; init; }
}
