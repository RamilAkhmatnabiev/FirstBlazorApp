using System.ComponentModel.DataAnnotations;

namespace FirstBlazorApp.Data.Models
{
    public record AuthorRecord : BaseNamedRecord
    {
        [Required] public string LastName { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        [StringLength(20, ErrorMessage = "To long")]
        public string City { get; set; }

        [EmailAddress] [Required] public string Email { get; set; }

        [Range(1000, Int32.MaxValue)] public int Salary { get; set; }
    }
}