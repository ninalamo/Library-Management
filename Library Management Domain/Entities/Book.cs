using System;
using System.Collections.Generic;
using System.Linq;

namespace Library_Management_Domain.Entities
{
    // https://bookcoverarchive.com/
    public class Book
    {
        public Guid Id { get; set; }
        public string? Title { get; set; } = default!;
        public string? ISBN { get; set; } = default!;
        public string? Description { get; set; } = default!;
        public string? Genre { get; set; } = default!;
        public DateTime? PublishedDate { get; set; } = default!;

        public bool IsArchived { get; set; } = false;
        public DateTime? ArchivedDate { get; set; }

        public Guid? AuthorId { get; set; }
        public Author? Author { get; set; }

        public List<BookCopy> Copies { get; set; } = new List<BookCopy>();

        // ✅ Computed properties
        public int TotalCopies => Copies.Count;

        public int AvailableCopies => Copies.Count(c => c.IsAvailable && c.PulloutDate == null);

        public int PulledOutCopies => Copies.Count(c => c.PulloutDate != null);
    }

    public class BookCopy
    {
        public Guid Id { get; set; }
        public string? CoverImageUrl { get; set; } = default!;
        public string? Condition { get; set; } = default!;
        public string? Source { get; set; } = default!;
        public DateTime? AddedDate { get; set; } = default!;
        public DateTime? PulloutDate { get; set; } = default!;
        public string? PulloutReason { get; set; } = default!;

        // ✅ New flag to track availability
        public bool IsAvailable { get; set; } = true;

        // Navigation back to Book
        public Book? Book { get; set; } = default!;
    }

    public class Author
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = default!;
        public string? Biography { get; set; } = default!;
        public DateTime? BirthDate { get; set; } = default!;
        public string? ProfileImageUrl { get; set; } = default!;
        
        // ✅ Archiving support
        public bool IsArchived { get; set; } = false;
        public DateTime? ArchivedDate { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
        
        // ✅ Computed properties
        public int ActiveBooksCount => Books.Count(b => !b.IsArchived);
        public int TotalBooksCount => Books.Count;
    }
}
