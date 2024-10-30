namespace CSOPS.DevChallenge.Clients.Models.ContactModels
{
	public class Note
	{
        public required string Id { get; set; }
		public required DateTime CreatedAtUTC { get; set; }
		public required string Content { get; set; }
		public required string CreatedBy { get; set; }
	}
}