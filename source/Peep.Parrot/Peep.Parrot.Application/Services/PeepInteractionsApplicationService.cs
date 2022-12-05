using Peep.EventBus;
using Peep.Parrot.Application.Dtos;
using Peep.Parrot.Application.Events;
using Peep.Parrot.Domain.Enums;
namespace Peep.Parrot.Application.Services;

public class PeepInteractionsApplicationService
{
    private readonly IEventBus _eventBus;
    private readonly IPeepsRepository _peepsRepository;

    public PeepInteractionsApplicationService(IEventBus eventBus, 
        IPeepsRepository peepsRepository)
    {
        _eventBus = eventBus;
        _peepsRepository = peepsRepository;
    }

    public async Task AddInstantInteraction(PeepInstantInteractionEntryDto interaction)
    {
        var peep = await _peepsRepository.GetById(interaction.PeepId);
        if (peep == null) return;

        var user = interaction.UserId;

        switch (interaction.InteractionType)
        {
            case EPeepInstantInteractionType.Like:
                peep.Like(user);
                await _eventBus.Publish(new PeepLiked(user, peep.Id));
                break;
            case EPeepInstantInteractionType.Rp:
                peep.Repeep(user);
                await _eventBus.Publish(new PeepReposted(user, peep.Id));
                break;
        }

        await _peepsRepository.UpdatePeep(peep);
    }

    public async Task RemoveInstantInteraction(PeepInstantInteractionEntryDto interaction)
    {
        var peep = await _peepsRepository.GetById(interaction.PeepId);
        if (peep == null) return;

        var user = interaction.UserId;

        switch (interaction.InteractionType)
        {
            case EPeepInstantInteractionType.Like:
                peep.RemoveLike(user);
                await _eventBus.Publish(new PeepDisliked(user, peep.Id));
                break;
            case EPeepInstantInteractionType.Rp:
                peep.RemoveRp(user);
                await _eventBus.Publish(new PeepDisreposted(user, peep.Id));
                break;
        }

        await _peepsRepository.UpdatePeep(peep);
    }

    public async Task CommitInteractionsFromAddedPeep(Domain.Entities.Peep peep)
    {
        var repliedPeepId = peep.RepliedPeepId;
        var quotedPeepId = peep.QuotedPeepId;

        if (repliedPeepId.HasValue)
        {
            await AddReplyToPeep(repliedPeepId.Value, peep);
        }

        if (quotedPeepId.HasValue)
        {
            await AddQuoteToPeep(quotedPeepId.Value, peep);
        }
    }

    public async Task RollbackInteractionsFromRemovedPeep(Domain.Entities.Peep peep)
    {
        var repliedPeepId = peep.RepliedPeepId;
        var quotedPeepId = peep.QuotedPeepId;

        if (repliedPeepId.HasValue)
        {
            await RemoveReplyFromPeep(repliedPeepId.Value, peep);
        }

        if (quotedPeepId.HasValue)
        {
            await RemoveQuoteFromPeep(quotedPeepId.Value, peep);
        }
    }

    private async Task AddReplyToPeep(Guid repliedPeepId, Domain.Entities.Peep reply)
    {
        var repliedPeep = await _peepsRepository.GetById(repliedPeepId);

        repliedPeep.AddReply(reply);
        await _peepsRepository.UpdatePeep(repliedPeep);

        await _eventBus.Publish(new PeepReplied(repliedPeepId, reply));
    }

    private async Task RemoveReplyFromPeep(Guid repliedPeepId, Domain.Entities.Peep reply)
    {
        var repliedPeep = await _peepsRepository.GetById(repliedPeepId);

        repliedPeep.RemoveReply(reply);
        await _peepsRepository.UpdatePeep(repliedPeep);

        await _eventBus.Publish(new PeepReplyRemoved(repliedPeepId, reply));
    }

    private async Task AddQuoteToPeep(Guid quotedPeepId, Domain.Entities.Peep quote)
    {
        var quotedPeep = await _peepsRepository.GetById(quotedPeepId);

        quotedPeep.AddQuote(quote);
        await _peepsRepository.UpdatePeep(quotedPeep);

        await _eventBus.Publish(new PeepQuoted(quotedPeepId, quote));
    }

    private async Task RemoveQuoteFromPeep(Guid quotedPeepId, Domain.Entities.Peep quote)
    {
        var quotedPeep = await _peepsRepository.GetById(quotedPeepId);

        quotedPeep.RemoveQuote(quote);
        await _peepsRepository.UpdatePeep(quotedPeep);

        await _eventBus.Publish(new PeepQuoteRemoved(quotedPeepId, quote));
    }
}
