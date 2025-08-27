namespace Library_Management.Models
{
    public class AuthorListViewModel
    {
        public Guid AuthorId { get; set; }
        public string? Name { get; set; }
        public string? Biography { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? ProfileImageUrl { get; set; }
        public int ActiveBooksCount { get; set; }
        public int TotalBooksCount { get; set; }
        public bool IsArchived { get; set; }
        public DateTime? ArchivedDate { get; set; }

        public string FormattedBirthDate => BirthDate?.ToString("MMMM dd, yyyy") ?? "Unknown";
        public int Age => BirthDate.HasValue ? DateTime.Now.Year - BirthDate.Value.Year - (DateTime.Now.DayOfYear < BirthDate.Value.DayOfYear ? 1 : 0) : 0;
        public string BooksStatus => $"{ActiveBooksCount} Active / {TotalBooksCount} Total";
    }
}
