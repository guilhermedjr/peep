using System;
using System.Collections.Generic;
using Peep.Parrot.Domain.Enums;

namespace Peep.Parrot.Domain.Entities
{
    public class Peep
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public bool IsQuote { get; set; }
        public Peep QuotedPeep { get; set; }
        public DateTime PublicationDateTime { get; set; }
        public string Description { get; set; }
        public EPeepSource Source { get; set; }
        public EPeepReplyRestriction ReplyRestriction { get; set; }
        public List<Peep> Quotes { get; set; }
        public List<User> Rps { get; set; }
        public List<User> Likes { get; set; }
        public List<Peep> Replies { get; set; }
    }
}
