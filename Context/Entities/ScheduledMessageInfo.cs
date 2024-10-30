using CSOPS.DevChallenge.Clients.Models.ContactModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSOPS.DevChallenge.Context.Entities
{
	public class ScheduledMessageInfo
	{
		[Key]
		public required string ScheduledMessageId { get; set; } = string.Empty;

		[Required]
		public required string Status { get; set; } = string.Empty; // [ Pending, Error, Sent, Canceled ]
		public bool Deleted { get; set; }

		[StringLength(20)]
		public string? ChannelReferenceId { get; set; }

		[StringLength(150)]
		public string? ChannelReferenceName { get; set; }

		[StringLength(20)]
		[ForeignKey(nameof(ContactInfo))]
		public required string ContactId { get; set; } = string.Empty;

		[NotMapped]
		public required ContactInfo Contact { get; set; } // propriedade de navegação
	}
}