namespace Trolley.API.Dtos
{
    public class CreateDonationDto
    {
        public string? SessionId { get; set; }
        public string? PubKey { get; set; }
        public long? Amount { get; set; }
    }
}
