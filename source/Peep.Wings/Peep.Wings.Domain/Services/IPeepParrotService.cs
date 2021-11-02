namespace Peep.Wings.Domain.Services;

public interface IPeepParrotService
{
    Task AddUser(SyncUserDto syncUserDto);
    Task UpdateUser(SyncUserDto syncUserDto);
}

