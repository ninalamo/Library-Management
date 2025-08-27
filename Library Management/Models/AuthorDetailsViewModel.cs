namespace Library_Management.Models
{
    public class AuthorDetailsViewModel
    {
        public Guid AuthorId { get; set; }
        public string? Name { get; set; }
        public string? Biography { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? ProfileImageUrl { get; set; }
        public bool IsArchived { get; set; }
        public DateTime? ArchivedDate { get; set; }

        public List<BookListViewModel> Books { get; set; } = new List<BookListViewModel>();

        public string FormattedBirthDate => BirthDate?.ToString("MMMM dd, yyyy") ?? "Unknown";
        public int Age => BirthDate.HasValue ? DateTime.Now.Year - BirthDate.Value.Year - (DateTime.Now.DayOfYear < BirthDate.Value.DayOfYear ? 1 : 0) : 0;
        public int ActiveBooksCount => Books.Count(b => !b.IsArchived);
        public int TotalBooksCount => Books.Count;
        public string ShortBiography => Biography?.Length > 200 ? Biography.Substring(0, 200) + "..." : Biography ?? "";
    }
}
