namespace Peep.Parrot.Domain.ValueObjects;

public record PeepContent
{
    private string _textContent;
    private string[] _media;

    public PeepContent(string textContent = null, string[] media = null, Poll poll = null)
    {
        _textContent = textContent;
        _media = media;
        Poll = poll;
    }

    public string TextContent { get { return _textContent; } }
    public string[] Media { get { return _media; } }
    public readonly Poll Poll;
}
