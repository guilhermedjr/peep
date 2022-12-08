using Peep.Parrot.Domain.SeedWork;
namespace Peep.Parrot.Domain.Aggregates.PeepAggregate;

public class PeepContent : ValueObject
{
    public PeepContent(string textContent, PeepMediaItem[] mediaItems, PeepPoll poll)
    {
        TextContent = textContent;
        MediaItems = mediaItems;
        Poll = poll;
    }

    public string TextContent { get; private set; }
    public PeepMediaItem[] MediaItems { get; private set; }
    public PeepPoll Poll { get; private set; }
}
