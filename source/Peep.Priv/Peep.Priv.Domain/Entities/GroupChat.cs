namespace Peep.Priv.Domain.Entities;

public class GroupChat
{
    public string Name { get; set; }
    public List<User> Members { get; set; }
    public List<Message> Messages { get; set; }
}
