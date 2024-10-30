using System.ComponentModel.DataAnnotations;

namespace CSOPS.DevChallenge.Clients.Models.ContactModels
{
	public class Address
	{
        public string? AddressLine1 { get; set; }
		public string? AddressLine2 { get; set; }
		public string? City { get; set; }
        [StringLength(2, MinimumLength = 2, ErrorMessage = "State must be exactly 2 characters")]
        public string? State { get; set; }
		public string? ZipCode { get; set; }
		public string? Country { get; set; }
	}
}
