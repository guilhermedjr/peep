using Peep.DomainEvents.Events.Peep;
using Peep.EventBus;
using Peep.Parrot.Application.Dtos;
using Peep.Parrot.Domain.Aggregates.PeepAggregate;
using Peep.Parrot.Domain.Enums;
namespace Peep.Parrot.Application.Services;

public class PeepApplicationService
{
    private readonly IEventBus _eventBus;
    private readonly IPeepsRepository _peepsRepository;
    private readonly PeepInteractionsApplicationService _peepInteractionsApplicationService;

    public PeepApplicationService(IEventBus eventBus, 
        IPeepsRepository peepsRepository, PeepInteractionsApplicationService peepInteractionsApplicationService)
    {
        _eventBus = eventBus;
        _peepsRepository = peepsRepository;
        _peepInteractionsApplicationService = peepInteractionsApplicationService;
    }

    public async Task AddPeep(PeepEntryDto peepEntryDto)
    {
        var sanitizedContent = SanitizeContent(peepEntryDto.PeepContentEntryDto);

        var repliedPeepId = peepEntryDto.RepliedPeepId;
        var quotedPeepId = peepEntryDto.QuotedPeepId;

        var newPeep = new Domain.Aggregates.PeepAggregate.Peep(peepEntryDto.UserId, sanitizedContent,
            EPeepSource.Undefined, peepEntryDto.ViewRestriction, peepEntryDto.ReplyRestriction,
            quotedPeepId, repliedPeepId);

        var peep = await _peepsRepository.AddPeep(newPeep);

        await _eventBus.Publish(new PeepAdded(
            peep.Id, peep.UserId, peep.PublicationDate, peep.PublicationTime,
            (byte)peep.Source, (byte)peep.ViewRestriction, (byte)peep.ReplyRestriction, peep.QuotedPeepId,
            peep.RepliedPeepId, peep.PeepContent
            ));

        await _peepInteractionsApplicationService.CommitInteractionsFromAddedPeep(peep);
    }

    public async Task ChangePeepReplyRestriction(ChangePeepReplyRestrictionDto peepDto)
    {
        var peep = await _peepsRepository.GetById(peepDto.PeepId);
        if (peep == null) return;

        peep.ChangeReplyRestriction(peepDto.ReplyRestriction);
        await _peepsRepository.UpdatePeep(peep);

        await _eventBus.Publish(new PeepReplyRestrictionChanged(peep.Id, (byte)peep.ReplyRestriction));
    }

    public async Task EditPeep(EditPeepDto editPeepDto)
    {
        var peep = await _peepsRepository.GetById(editPeepDto.PeepId);
        if (peep == null) return;

        var sanitizedContent = SanitizeContent(editPeepDto.PeepContentEntryDto);

        peep.EditPeep(sanitizedContent);
        var editedPeep = await _peepsRepository.UpdatePeep(peep);

        await _eventBus.Publish(new PeepEdited(editedPeep.Id, editedPeep.PeepContent, editedPeep.PublicationDate, editedPeep.PublicationTime));
    }

    public async Task RemovePeep(Guid id)
    {
        var peep = await _peepsRepository.GetById(id);
        if (peep == null) return;

        await _peepsRepository.DeletePeep(id);
        await _eventBus.Publish(new PeepRemoved(id));

        await _peepInteractionsApplicationService.RollbackInteractionsFromRemovedPeep(peep);
    }

    private static PeepContent SanitizeContent(PeepContentEntryDto peepContentEntry)
    {
        return new PeepContent(peepContentEntry.TextContent, mediaItems: null, poll: null);
    }
}