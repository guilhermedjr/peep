namespace Peep.Parrot.Domain.Entities;

public class Poll
{
    private Dictionary<string, int> _choices;
    private Dictionary<string, IList<Guid>> _votingUsers;

    public Poll(string[] pollOptions, DateTime closingTime)
    {
        _choices = new Dictionary<string, int>();

        foreach (var option in pollOptions)
        {
            _choices.Add(option, 0);
            _votingUsers.Add(option, new List<Guid>());
        }

        ClosingTime = closingTime;
    }

    public Dictionary<string, int> Choices { get { return _choices; } }
    public Dictionary<string, IList<Guid>> VotingUsers { get { return _votingUsers; } }

    public bool Closed { get; private set; }

    public readonly DateTime ClosingTime;

    public void AddChoice(Guid user, string option)
    {
        _choices[option] += 1;
        _votingUsers[option].Add(user);
    }
}