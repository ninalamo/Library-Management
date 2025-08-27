using System.ComponentModel.DataAnnotations;

namespace Library_Management.Models
{
    public class PulloutBookCopyViewModel
    {
        public Guid BookCopyId { get; set; }
        public Guid BookId { get; set; }
        public string? BookTitle { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? Condition { get; set; }
        public string? Source { get; set; }
        public DateTime? AddedDate { get; set; }

        [Required(ErrorMessage = "Please specify a reason for pulling out this book copy")]
        [StringLength(500, ErrorMessage = "Reason cannot exceed 500 characters")]
        public string PulloutReason { get; set; } = string.Empty;

        public string FormattedAddedDate => AddedDate?.ToString("MMMM dd, yyyy") ?? "Unknown";
    }
}
