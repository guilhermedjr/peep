﻿using Peep.Parrot.Domain.Repository;
using System;
using System.Threading.Tasks;

namespace Peep.Parrot.Repositories
{
    public class UsersConnectionsRepository : IUsersConnectionsRepository
    {
        public Task RequestFollowUp(Guid requestingUserId, Guid requestedUserId)
        {
            throw new NotImplementedException();
        }

        public Task AddFollowUp(Guid followerId, Guid followedId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFollowUp(Guid followerId, Guid followedId)
        {
            throw new NotImplementedException();
        }

        public Task GetUserFollowRequests(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}