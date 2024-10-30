using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSOPS.DevChallenge.Context.Entities
{

	/// <summary>
	/// Essa classe implementa o histórico de buscas de chats, salvando o estado dos dados do chat no momento da pesquisa
	/// </summary>
	public class SearchHistoryInfo
	{
		[Key]
        public int SearchHistoryId { get; set; }
		public bool IsAnyAttendantAssigned { get; set; }
		public bool IsWaiting { get; set; }
		public DateTime? LastMessageTime { get; set; }

		[StringLength(20)]
		public string? LastMessageSource { get; set; }

		[StringLength(20)]
		public string? LastMessageState { get; set; }

		[StringLength(20)]
		public string? MemberId { get; set; }

		[StringLength(20)]
		public string? LastAttendantId { get; set; }

		[StringLength(20)]
		[ForeignKey(nameof(ChatInfo))]
		public required string ChatId { get; set; } = string.Empty; // no chat já temos as informações do contato

        [NotMapped]
        public ChatInfo? Chat { get; set; } // navegação
    }
}