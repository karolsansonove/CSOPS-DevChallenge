using CSOPS.DevChallenge.Clients;
using CSOPS.DevChallenge.Clients.Models.ChatModels;
using CSOPS.DevChallenge.Context;
using CSOPS.DevChallenge.Context.Entities;

namespace CSOPS.DevChallenge.Services;

public interface ISearchHistoryInfoService
{
	IEnumerable<SearchHistoryInfo> GetHistory();
	Task<SearchHistoryInfo?> AddToContextAsync(Chat chat);
}

public class SearchHistoryInfoService(ChallengeContext context) : ISearchHistoryInfoService
{
	public IEnumerable<SearchHistoryInfo> GetHistory()
	{
		return context.SearchHistoryInfos.ToList();
	}

	public async Task<SearchHistoryInfo?> AddToContextAsync(Chat chat)
	{
		var searchHistoryInfo = CreateSearchHistory(chat);
		await context.SearchHistoryInfos.AddAsync(searchHistoryInfo);

		return searchHistoryInfo;
	}

	private SearchHistoryInfo CreateSearchHistory(Chat chat)
	{
		return new SearchHistoryInfo()
		{
			IsAnyAttendantAssigned = chat.OrganizationMember?.Id != null,
			IsWaiting = chat.LastMessage?.Source == "Contact",
			LastMessageTime = chat.LastMessage?.EventAtUtc,
			LastMessageSource = chat.LastMessage?.Source,
			LastMessageState = chat.LastMessage?.MessageState,
			MemberId = chat.OrganizationMember?.Id,
			LastAttendantId = chat.LastOrganizationMember?.Id,
			ChatId = chat.Id
		};
	}

}
