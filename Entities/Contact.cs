using System.ComponentModel.DataAnnotations;

namespace ContactManangement.Entities
{
    [Serializable]
    public class Contact
    {
        [Key]
        public string ContactId { get; set; } = string.Empty;
        public string ContactName { get; set; } = string.Empty;
        public int ContactPhone { get; set; }
        public string ContactEmail { get; set; } = string.Empty;     
        public string ContactAddress { get; set; } = string.Empty;
    }
}
