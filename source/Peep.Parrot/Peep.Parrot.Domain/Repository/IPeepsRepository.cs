namespace Peep.Parrot.Domain.Repository;

public interface IPeepsRepository
{
    Task<bool> AddPeep(AddPeepDto addPeepDto);
    Task<bool> EditPeep(EditPeepDto editPeepDto);
    Task<bool> DeletePeep(Guid userId, Guid peepId);
}

