using CSOPS.DevChallenge.Clients.Models.ContactModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace CSOPS.DevChallenge.Context.Entities;

//public interface IContactInfo {}

public class ContactInfo
{

	[Key]
	public required string ContactId { get; set; } = string.Empty;

	[StringLength(100)]
	public string? Name { get; set; }

	[StringLength(20)]
	public string? Gender { get; set; }

	[StringLength(100)]
	public string? Email { get; set; }

	[Required]
	[StringLength(14)]
	public required string PhoneNumber { get; set; } = string.Empty;

	[StringLength(50)]
	public string? AddressLine1 { get; set; }

	[StringLength(50)]
	public string? AddressLine2 { get; set; }

	[StringLength(50)]
	public string? City { get; set; }

	[StringLength(2)]
	public string? State { get; set; }

	[StringLength(9)]
	public string? ZipCode { get; set; }

	[StringLength(50)]
	public string? Country { get; set; }

	public DateTime? LastActiveUtc { get; set; }
	public string? ProfilePictureUrl { get; set; }
	public bool IsOptIn { get; set; }
	public bool IsBlocked { get; set; }
	public string? GroupIdentifier { get; set; }
	public int? Landline { get; set; }
	public DateTime? CreatedAtUTC { get; set; }
}
