using CSOPS.DevChallenge.Clients.Models.ChatModels;
using CSOPS.DevChallenge.Clients.Models.ContactModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSOPS.DevChallenge.Context.Entities;

//public interface IChatInfo { }

public class ChatInfo // essa classe eu uso para manipular o banco de dados
{
	[Key]
    [StringLength(20)] // o tamanho padrão é 450, então reduzi porque o Id não precisa de tanto espaço
    public required string ChatId { get; set; } = string.Empty;
	public bool IsAnyAttendantAssigned { get; set; }

	public DateTime? CreatedAtUtc { get; set; }

	[StringLength(20)]
	public string? LastAttendantId { get; set; }
    public bool IsWaiting { get; set; }

	[StringLength(20)]
	public string? LastMessageId { get; set; }

	public string? LastMessageContent { get; set; }

	[StringLength(20)]
	public string? LastMessageSource { get; set; }

	[StringLength(20)]
	public string? LastMessageState { get; set; }

	public DateTime? LastMessageTime { get; set; }
	public DateTime? WaitingSince { get; set; }

	[StringLength(20)]
	public string? CurrentMemberId { get; set; }

	[StringLength(20)]
	[ForeignKey(nameof(ContactInfo))]
	public required string ContactId { get; set; } = string.Empty;

	[NotMapped]
	public required ContactInfo Contact { get; set; }

	public string? calculateWaitingTime()
	{
		if (this.WaitingSince.HasValue)
		{
			TimeSpan waitingTime = DateTime.UtcNow - this.WaitingSince.Value;

			return $"{(int)waitingTime.TotalHours}h{waitingTime.Minutes}min";
		}
		return null;
	}
}
