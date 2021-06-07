﻿using System;

namespace Peep.Parrot.Domain.ViewModels
{
    public class UserInfoViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Bio { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
    }
}
