using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSOPS.DevChallenge.Context.Entities
{
	public class NoteInfo
	{
		[Key]
		[StringLength(20)]
		public required string Id { get; set; } = string.Empty;

		[StringLength(20)]
		public string? CreatedBy { get; set; }
		public DateTime? CreatedAtUTC { get; set; }
		public string? Content { get; set; }

		[StringLength(20)]
		[ForeignKey(nameof(ContactInfo))]
        public required string ContactId { get; set; } = string.Empty;

		[NotMapped]
        public required ContactInfo Contact { get; set; }
	}
}
