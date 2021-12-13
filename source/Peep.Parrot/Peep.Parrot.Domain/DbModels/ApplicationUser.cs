namespace Peep.Parrot.Domain.Entities;

/* Attributes created for correct mapping of data to SQL databases */
public partial class ApplicationUser
{
    private readonly IList<Followship> _followships;
    private readonly IList<Mute> _mutes;
    private readonly IList<Block> _blocks;

    /// <summary>
    /// ORM constructor
    /// </summary>
    private ApplicationUser() { }

    public IReadOnlyCollection<Followship> Followships { get { return _followships.ToArray(); } }
    public IReadOnlyCollection<Mute> Mutes { get { return _mutes.ToArray(); } }
    public IReadOnlyCollection<Block> Blocks { get { return _blocks.ToArray(); } }

}

