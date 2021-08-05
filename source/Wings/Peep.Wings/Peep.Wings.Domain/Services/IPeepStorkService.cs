﻿using System.Threading.Tasks;
using Peep.Wings.Domain.Dtos;

namespace Peep.Wings.Domain.Services
{
    public interface IPeepStorkService
    {
        Task AddUser(SyncUserDto syncUserDto);
        Task UpdateUser(SyncUserDto syncUserDto);
    }
}