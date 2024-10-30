namespace CSOPS.DevChallenge.Clients.Models.ChatModels
{
    public class LastMessage
    {
        public required string Id { get; set; } = string.Empty;
		public string? Content { get; set; }
        public required string Source { get; set; } = string.Empty;
		public required string MessageState { get; set; } = string.Empty;
		public DateTime? EventAtUtc { get; set; }
    }
}
