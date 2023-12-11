using System.ComponentModel.DataAnnotations.Schema;

namespace Trolley.API.Entities
{
    [Table(nameof(Donation))]
    public class Donation : BaseEntity
    {
        public string? AppUserId { get; set; }
        public string? PaymentIntentId { get; set; }
        public string? PaymentStatus { get; set; }
        public long Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string ReceiptEmail { get; set; }
        public string? CustomerId { get; set; }
        public DateTime PaymentDate { get; set; }
        public virtual AppUser User { get; set; }
    }
}
