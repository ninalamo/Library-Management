namespace Library_Management.Models
{
    public class BookListViewModel
    {
        public Guid BookId { get; set; }
        public string? Title { get; set; } = default!;
        public string? ISBN { get; set; } = default!;
        public string? Description { get; set; } = default!;
        public string? Genre { get; set; } = default!;
        public DateTime? PublishedDate { get; set; } = default!;
        public string? CoverImageUrl { get; set; } = default!;

        public Guid? AuthorId { get; set; }
        public string? AuthorName { get; set; } = default!;
        public string? AuthorProfileImageUrl { get; set; } = default!;
        
        public int TotalCopies { get; set; } = 0;
        public int AvailableCopies { get; set; } = 0;
        public int PulledOutCopies { get; set; } = 0;
        
        public bool IsArchived { get; set; } = false;
        public DateTime? ArchivedDate { get; set; }

        public string FormattedPublishedDate => PublishedDate?.ToString("MMMM dd, yyyy") ?? "Unknown";
        public string ShortDescription => Description?.Length > 100 ? Description.Substring(0, 100) + "..." : Description ?? "";
        public string CopiesStatus => $"{AvailableCopies} Available / {TotalCopies} Total" + (PulledOutCopies > 0 ? $" ({PulledOutCopies} Pulled Out)" : "");
    }
}
