using System;
using System.Net;
using System.Text;
using System.Text.Json;
using Azure;
using CSOPS.DevChallenge.Clients.Models.ChatModels;
using CSOPS.DevChallenge.Clients.Models.ContactModels;
using CSOPS.DevChallenge.Services;

namespace CSOPS.DevChallenge.Clients;

public interface ITalkClient
{
    Task<Chat?> GetChatAsync(string chatId);
    Task<Contact?> GetContactAsync(string contactId);
    Task UpdateContactAsync(Contact updatedContact);
}
public class TalkClient(HttpClient client) : ITalkClient
{
    public static readonly string OrgId = "YT-h9PtKxKdBtkrR";
    private static readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public async Task<Chat?> GetChatAsync(string chatId)
    {
        var res = await client.GetAsync($"chats/{chatId}/?organizationId={OrgId}");

        if (res.StatusCode == HttpStatusCode.Forbidden)
            throw new Exception("Could not get chats from Talk... Are we under the VPN?");
        
        if (res.StatusCode == HttpStatusCode.NotFound)
            throw new Exception("Chat not found.");

        if (!res.IsSuccessStatusCode)
            throw new HttpRequestException($"Error: {res.StatusCode} when trying to search chat. Maybe the Id is wrong.");

        var chat = JsonSerializer.Deserialize<Chat?>(res.Content.ReadAsStream(), _options);

        if (chat?.Id == null)
            return null;

        return chat;
    }

	public async Task<Contact?> GetContactAsync(string contactId)
	{
		var res = await client.GetAsync($"contacts/{contactId}/?organizationId={OrgId}");

		if (res.StatusCode == HttpStatusCode.Forbidden)
			throw new Exception("Could not get contact from Talk... Are we under the VPN?");

		var contact = JsonSerializer.Deserialize<Contact?>(res.Content.ReadAsStream(), _options);

		if (contact?.Id == null)
			return null;

		return contact;
	}

    public async Task UpdateContactAsync(Contact updatedContact)
    {
        var contactJson = JsonSerializer.Serialize(updatedContact);
        var content = new StringContent(contactJson, Encoding.UTF8, "application/json");

        var res = await client.PutAsync($"contacts/{updatedContact.Id}/?organizationId={OrgId}", content);

        if (res.IsSuccessStatusCode) return;

        if (res.StatusCode == HttpStatusCode.Forbidden)
            throw new Exception("Could not update contact in Talk... Are we under the VPN?");

        throw new HttpRequestException($"Failed to update contact. Status code: {res.StatusCode}");
    }
}
