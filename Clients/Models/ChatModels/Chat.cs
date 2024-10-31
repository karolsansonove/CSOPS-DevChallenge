using System.ComponentModel.DataAnnotations;
using CSOPS.DevChallenge.Clients.Models.ContactModels;

namespace CSOPS.DevChallenge.Clients.Models.ChatModels;

public class Chat
{
    public required string Id { get; set; }
    public bool HasMessagesBeforeAllowedHistory { get; set; }
    public OrganizationMember? OrganizationMember { get; set; }
    public required Contact Contact { get; set; }
    public LastMessage? LastMessage { get; set; }
    public LastOrganizationMember? LastOrganizationMember { get; set; }	
	public required DateTime CreatedAtUtc { get; set; }
	
}