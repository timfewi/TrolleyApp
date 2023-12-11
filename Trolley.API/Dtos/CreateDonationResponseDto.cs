namespace Trolley.API.Dtos
{
    public class CreateDonationResponseDto
    {
        public string? SessionId { get; set; }
        public string? PubKey { get; set; }
        public long? Amount { get; set; }
    }
}
