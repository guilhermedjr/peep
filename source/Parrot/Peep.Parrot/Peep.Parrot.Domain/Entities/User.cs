using System;
using System.Collections.Generic;

namespace Peep.Parrot.Domain.Entities
{
    public class User 
    {
        public Guid Id { get; set; }
        public bool IsPrivateAccount { get; set; } 
        public string Name { get; set; }
        public string Username { get; set; }
        public string Bio { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public List<User> Following { get; set; }
        public List<User> Followers { get; set; }
        public List<Peep> Peeps { get; set; }
        public List<Nest> UserNests { get; set; }
        public List<Nest> Nests { get; set; }
        public List<User> FollowRequests { get; set; }
        public List<User> BlockedUsers { get; set; }
        public List<User> SilencedUsers { get; set; }
 
    }
}
