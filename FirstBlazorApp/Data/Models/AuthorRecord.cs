using System.ComponentModel.DataAnnotations;

namespace FirstBlazorApp.Data.Models
{
    public record AuthorRecord
    {
        public int AuthorId { get; set; }
        public int AuthorIdNew { get; set; }
        [Required] public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Name is required")]
        public string FirstName { get; set; } = null!;

        [Required] public string Phone { get; set; } = null!;
        public string? Address { get; set; }

        [StringLength(20, ErrorMessage = "To long")]
        public string? City { get; set; }

        public string? State { get; set; }

        public string? Zip { get; set; }

        [EmailAddress] [Required] public string? EmailAddress { get; set; }

        [Range(1000, Int32.MaxValue)] public int Salary { get; set; }

        public string Description { get; set; }
    }
}