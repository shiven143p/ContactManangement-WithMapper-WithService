using System.ComponentModel.DataAnnotations;

namespace ContactManangement.Entities.Dto
{
    public class ContactDto
    {
        [Required]
        public string ContactId { get; set; } = string.Empty;
        [Required]
        public string ContactName { get; set; } = string.Empty;
        [Required]
        public int ContactPhone { get; set; }
        public string ContactEmail { get; set; } = string.Empty;
        public string ContactAddress { get; set; } = string.Empty;
    }
}
