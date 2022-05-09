namespace Peep.Priv.Domain.Entities;

public class Message
{
    public string TextContent { get; set; }
    public DateTime DateTime { get; set; }
    public User From { get; set; }
    public User To { get; set; }
}
