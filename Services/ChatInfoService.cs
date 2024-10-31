using CSOPS.DevChallenge.Clients;
using CSOPS.DevChallenge.Clients.Models.ChatModels;
using CSOPS.DevChallenge.Clients.Models.ContactModels;
using CSOPS.DevChallenge.Context;
using CSOPS.DevChallenge.Context.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CSOPS.DevChallenge.Services;

public interface IChatInfoService
{
	Task<ChatInfo?> GetAsync(string chatId);
}

public class ChatInfoService(
	ITalkClient talkClient, 
	ChallengeContext context,
	IContactInfoService contactInfoService,
	ISearchHistoryInfoService searchHistoryInfoService) : IChatInfoService
{
	public async Task<ChatInfo?> GetAsync(string chatId)
	{
		var chat = await talkClient.GetChatAsync(chatId);
		if (chat == null) return null;

		var contactInfo = await contactInfoService.GetAsync(chat.Contact.Id);
		if (contactInfo == null) return null;

		var existingChat = await context.ChatInfos.FirstOrDefaultAsync(c => c.ChatId == chat.Id);
		
		if (existingChat != null)
		{
			UpdateExistingChat(existingChat, chat, contactInfo);
		}
		else
		{
			var chatInfo = CreateChatInfo(chat, contactInfo);
			await context.ChatInfos.AddAsync(chatInfo);
			existingChat = chatInfo;
		}

		await searchHistoryInfoService.AddToContextAsync(chat);

		await context.SaveChangesAsync();

		return existingChat;
	}

		private ChatInfo CreateChatInfo(Chat chat, ContactInfo contactInfo)
	{
		return new ChatInfo()
		{
			ChatId = chat.Id,
			IsAnyAttendantAssigned = chat.OrganizationMember != null,
			CreatedAtUtc = chat.CreatedAtUtc,
			LastAttendantId = chat.LastOrganizationMember?.Id,
			IsWaiting = chat.LastMessage?.Source == "Contact",
			LastMessageSource = chat.LastMessage?.Source,
			LastMessageState = chat.LastMessage?.MessageState,
			LastMessageTime = chat.LastMessage?.EventAtUtc,
			LastMessageContent = chat.LastMessage?.Content,
			WaitingSince = chat.LastMessage?.EventAtUtc,
			CurrentMemberId = chat.OrganizationMember?.Id,
			ContactId = chat.Contact.Id,
			Contact = contactInfo
		};
	}

	private void UpdateExistingChat(ChatInfo existingChat, Chat chat, ContactInfo contactInfo)
	{
		existingChat.IsAnyAttendantAssigned = chat.OrganizationMember != null;
		existingChat.CreatedAtUtc = chat.CreatedAtUtc;
		existingChat.LastAttendantId = chat.LastOrganizationMember?.Id;
		existingChat.IsWaiting = chat.LastMessage?.Source == "Contact";
		existingChat.LastMessageSource = chat.LastMessage?.Source;
		existingChat.LastMessageState = chat.LastMessage?.MessageState;
		existingChat.LastMessageTime = chat.LastMessage?.EventAtUtc;
		existingChat.LastMessageContent = chat.LastMessage?.Content;
		existingChat.CurrentMemberId = chat.OrganizationMember?.Id;
		existingChat.ContactId = chat.Contact.Id;

		if (existingChat.IsWaiting && existingChat.WaitingSince == null)
			existingChat.WaitingSince = chat.LastMessage?.EventAtUtc;
		
		if(!existingChat.IsWaiting)
			existingChat.WaitingSince = null;
	}
}