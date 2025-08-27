namespace Library_Management.Models
{
    public class DeleteAuthorViewModel
    {
        public Guid AuthorId { get; set; }
        public string? Name { get; set; }
        public string? Biography { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? ProfileImageUrl { get; set; }
        public int ActiveBooksCount { get; set; }
        public int TotalBooksCount { get; set; }

        public string FormattedBirthDate => BirthDate?.ToString("MMMM dd, yyyy") ?? "Unknown";
        public string ShortBiography => Biography?.Length > 150 ? Biography.Substring(0, 150) + "..." : Biography ?? "";
        public string BooksWarning => ActiveBooksCount > 0 
            ? $"Warning: This author has {ActiveBooksCount} active book(s). Deleting this author will also archive all their books." 
            : "This author has no active books.";
    }
}
