namespace Peep.Parrot.Application.Dtos;

public record EditPeepDto
{
    public Guid PeepId { get; init; }
    public PeepContentEntryDto PeepContentEntryDto { get; init; }
}
