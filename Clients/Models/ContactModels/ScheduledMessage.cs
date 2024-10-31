namespace CSOPS.DevChallenge.Clients.Models.ContactModels;

public class ScheduledMessage
{
    public required string Id { get; set; }
    public required string Status { get; set; }
    public bool Deleted { get; set; }
    public ChannelReference? ChannelReference { get; set; }
}