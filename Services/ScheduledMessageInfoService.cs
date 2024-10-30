using CSOPS.DevChallenge.Clients;
using CSOPS.DevChallenge.Context.Entities;
using CSOPS.DevChallenge.Context;
using CSOPS.DevChallenge.Clients.Models.ContactModels;

namespace CSOPS.DevChallenge.Services;

public interface IScheduledMessageInfoService
{
	Task AddScheduledMessagesAsync(Contact contact, ContactInfo contactInfo);
}

public class ScheduledMessageInfoService(ChallengeContext context) : IScheduledMessageInfoService
{
	public async Task AddScheduledMessagesAsync(Contact contact, ContactInfo contactInfo)
	{
		if (contact.ScheduledMessages == null) return;

		foreach (var message in contact.ScheduledMessages)
		{
			var existingScheduledMessage = context.ScheduledMessageInfos.FirstOrDefault(sm => sm.ScheduledMessageId == message.Id);
			if (existingScheduledMessage != null) // essa nota existe
			{
				UpdateExistingChat(existingScheduledMessage, message, contactInfo); // atualizar no contexto
			}
			else {  // nota não existe
				var scheduledMessageInfo = CreateScheduledMessageInfo(message, contactInfo);
				await context.ScheduledMessageInfos.AddAsync(scheduledMessageInfo);
				existingScheduledMessage = scheduledMessageInfo;
			}

		}
	}

	private ScheduledMessageInfo CreateScheduledMessageInfo(ScheduledMessage scheduledMessage, ContactInfo contact)
	{
		return new ScheduledMessageInfo()
		{
			ScheduledMessageId = scheduledMessage.Id,
			Status = scheduledMessage.Status,
			Deleted = scheduledMessage.Deleted,
			ChannelReferenceId = scheduledMessage.ChannelReference?.Id,
			ChannelReferenceName = scheduledMessage.ChannelReference?.Name,
			ContactId = contact.ContactId,
			Contact = contact
		};
	}

	private void UpdateExistingChat(ScheduledMessageInfo existingScheduledMessage, ScheduledMessage sm, ContactInfo contactInfo)
	{
		existingScheduledMessage.Status = sm.Status;
		existingScheduledMessage.Deleted = sm.Deleted;
		existingScheduledMessage.ChannelReferenceId = sm.ChannelReference?.Id;
		existingScheduledMessage.ChannelReferenceName = sm.ChannelReference?.Name;
		existingScheduledMessage.ContactId = contactInfo.ContactId;
		existingScheduledMessage.Contact = contactInfo;
	}
}