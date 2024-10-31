using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.RegularExpressions;

namespace CSOPS.DevChallenge.Clients.Models.ContactModels;

public class Contact
{
	public required string Id { get; set; } = string.Empty;
	public string? Name { get; set; }
	public string? Gender { get; set; }

    [EmailAddress(ErrorMessage = "Email is not valid")]
    public string? Email { get; set; }
	public DateTime? LastActiveUtc { get; set; }
	public required string PhoneNumber { get; set; } = string.Empty;
    public string? ProfilePictureUrl { get; set; }
    public bool IsOptIn { get; set; }
    public bool IsBlocked { get; set; }
	public string? Landline { get; set; }
	public string? GroupIdentifier { get; set; }
	public ICollection<string> ChannelIds { get; set; } = new List<string>();
	public DateTime? CreatedAtUTC { get; set; }
    public ICollection<Tag>? Tags { get; set; }
	public Address? Address { get; set; }
	public ICollection<Note>? Notes { get; set; }
	public ICollection<ScheduledMessage>? ScheduledMessages { get; set; }
}