using Library_Management.Models;
using Library_Management_Domain.Entities;

public class BookService
{
    private readonly ICollection<Book> _books = new List<Book>();
    private readonly ICollection<Author> _authors = new List<Author>();
    private readonly ICollection<BookCopy> _bookCopies = new List<BookCopy>();

    private BookService()
    {
        SeedData();
    }

    private void SeedData()
    {
        // === First Book ===
        var author1 = new Author
        {
            Id = Guid.NewGuid(),
            Name = "George Orwell",
            Biography = "English novelist, essayist, journalist and critic.",
            BirthDate = new DateTime(1903, 6, 25),
            ProfileImageUrl = "https://example.com/orwell.jpg",
            Books = new List<Book>()
        };

        var book1 = new Book
        {
            Id = Guid.NewGuid(),
            Title = "1984",
            ISBN = "9780451524935",
            Description = "A dystopian social science fiction novel and cautionary tale.",
            Genre = "Fiction",
            PublishedDate = new DateTime(1949, 6, 8)
        };

        var bookItem1 = new BookCopy
        {
            Id = Guid.NewGuid(),
            CoverImageUrl = "https://bookcoverarchive.com/wp-content/uploads/amazon/1984.jpg",
            Condition = "Good",
            Source = "Donation",
            AddedDate = DateTime.Now.AddMonths(-2),
            Book = book1
        };

        author1.Books.Add(book1);

        // === Second Book ===
        var author2 = new Author
        {
            Id = Guid.NewGuid(),
            Name = "J.K. Rowling",
            Biography = "British author, best known for the Harry Potter series.",
            BirthDate = new DateTime(1965, 7, 31),
            ProfileImageUrl = "https://example.com/rowling.jpg",
            Books = new List<Book>()
        };

        var book2 = new Book
        {
            Id = Guid.NewGuid(),
            Title = "Harry Potter and the Philosopher's Stone",
            ISBN = "9780747532699",
            Description = "The first novel in the Harry Potter series.",
            Genre = "Fantasy",
            PublishedDate = new DateTime(1997, 6, 26)
        };

        var bookItem2 = new BookCopy
        {
            Id = Guid.NewGuid(),
            CoverImageUrl = "https://contentful.harrypotter.com/usf1vwtuqyxm/2DCs73x6P8seNobQ9zBSbO/1a5dfd6ed5fc0ed9545370470fc3d74c/English_Harry_Potter_1_Epub_9781781100219.jpg",
            Condition = "Excellent",
            Source = "Purchase",
            AddedDate = DateTime.Now.AddMonths(-6),
            Book = book2
        };

        author2.Books.Add(book2);

        // === Extra Books ===
        var extraBooks = new[]
        {
            new {
                Author = new Author
                {
                    Id = Guid.NewGuid(),
                    Name = "Harper Lee",
                    Biography = "American novelist best known for To Kill a Mockingbird.",
                    BirthDate = new DateTime(1926, 4, 28),
                    ProfileImageUrl = "https://example.com/harper.jpg",
                    Books = new List<Book>()
                },
                Book = new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "To Kill a Mockingbird",
                    ISBN = "9780061120084",
                    Description = "A novel about racial injustice in the Deep South.",
                    Genre = "Classic",
                    PublishedDate = new DateTime(1960, 7, 11)
                },
                Cover = "https://images-na.ssl-images-amazon.com/images/I/81OdwZG5SSL.jpg"
            },
            new {
                Author = new Author
                {
                    Id = Guid.NewGuid(),
                    Name = "J.R.R. Tolkien",
                    Biography = "English writer, poet, philologist, and academic.",
                    BirthDate = new DateTime(1892, 1, 3),
                    ProfileImageUrl = "https://example.com/tolkien.jpg",
                    Books = new List<Book>()
                },
                Book = new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "The Hobbit",
                    ISBN = "9780547928227",
                    Description = "A fantasy novel about Bilbo Baggins' adventure.",
                    Genre = "Fantasy",
                    PublishedDate = new DateTime(1937, 9, 21)
                },
                Cover = "https://m.media-amazon.com/images/I/81t2CVWEsUL.jpg"
            },
            new {
                Author = new Author
                {
                    Id = Guid.NewGuid(),
                    Name = "F. Scott Fitzgerald",
                    Biography = "American novelist and short story writer.",
                    BirthDate = new DateTime(1896, 9, 24),
                    ProfileImageUrl = "https://example.com/fitzgerald.jpg",
                    Books = new List<Book>()
                },
                Book = new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "The Great Gatsby",
                    ISBN = "9780743273565",
                    Description = "A story of the mysterious Jay Gatsby and the American dream.",
                    Genre = "Classic",
                    PublishedDate = new DateTime(1925, 4, 10)
                },
                Cover = "https://m.media-amazon.com/images/I/81af+MCATTL.jpg"
            },
            new {
                Author = new Author
                {
                    Id = Guid.NewGuid(),
                    Name = "Suzanne Collins",
                    Biography = "American television writer and author.",
                    BirthDate = new DateTime(1962, 8, 10),
                    ProfileImageUrl = "https://example.com/collins.jpg",
                    Books = new List<Book>()
                },
                Book = new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "The Hunger Games",
                    ISBN = "9780439023481",
                    Description = "A dystopian novel set in the post-apocalyptic nation of Panem.",
                    Genre = "Dystopian",
                    PublishedDate = new DateTime(2008, 9, 14)
                },
                Cover = "https://m.media-amazon.com/images/I/61JfGcL2ljL.jpg"
            },
            new {
                Author = new Author
                {
                    Id = Guid.NewGuid(),
                    Name = "Mary Shelley",
                    Biography = "English novelist best known for Frankenstein.",
                    BirthDate = new DateTime(1797, 8, 30),
                    ProfileImageUrl = "https://example.com/shelley.jpg",
                    Books = new List<Book>()
                },
                Book = new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Frankenstein",
                    ISBN = "9780486282114",
                    Description = "A gothic novel about Victor Frankenstein and his creation.",
                    Genre = "Horror",
                    PublishedDate = new DateTime(1818, 1, 1)
                },
                Cover = "https://m.media-amazon.com/images/I/81Fhc2wAE0L.jpg"
            },
            // NEW BOOK 1
            new {
                Author = new Author
                {
                    Id = Guid.NewGuid(),
                    Name = "Jane Austen",
                    Biography = "English novelist known primarily for her six major novels.",
                    BirthDate = new DateTime(1775, 12, 16),
                    ProfileImageUrl = "https://example.com/austen.jpg",
                    Books = new List<Book>()
                },
                Book = new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Pride and Prejudice",
                    ISBN = "9781503290563",
                    Description = "A romantic novel of manners that depicts issues of class, marriage, and morality.",
                    Genre = "Romance",
                    PublishedDate = new DateTime(1813, 1, 28)
                },
                Cover = "https://m.media-amazon.com/images/I/81OthjkJBuL.jpg"
            },
            // NEW BOOK 2
            new {
                Author = new Author
                {
                    Id = Guid.NewGuid(),
                    Name = "Herman Melville",
                    Biography = "American novelist, short story writer, and poet of the American Renaissance period.",
                    BirthDate = new DateTime(1819, 8, 1),
                    ProfileImageUrl = "https://example.com/melville.jpg",
                    Books = new List<Book>()
                },
                Book = new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Moby-Dick",
                    ISBN = "9781503280786",
                    Description = "The narrative of Captain Ahab's obsessive quest to kill the white whale, Moby Dick.",
                    Genre = "Adventure",
                    PublishedDate = new DateTime(1851, 10, 18)
                },
                Cover = "https://m.media-amazon.com/images/I/81PRVYvXfNL.jpg"
            }
        };

        // Add extras to collections
        _authors.Add(author1);
        _authors.Add(author2);
        _books.Add(book1);
        _books.Add(book2);
        _bookCopies.Add(bookItem1);
        _bookCopies.Add(bookItem2);

        var rng = new Random();
        foreach (var entry in extraBooks)
        {
            entry.Author.Books.Add(entry.Book);
            _authors.Add(entry.Author);
            _books.Add(entry.Book);
            _bookCopies.Add(new BookCopy
            {
                Id = Guid.NewGuid(),
                CoverImageUrl = entry.Cover,
                Condition = "New",
                Source = "Purchase",
                AddedDate = DateTime.Now.AddDays(-rng.Next(1, 365)),
                Book = entry.Book
            });
        }
    }

    public void AddBook(AddBookViewModel book)
    {
        ArgumentNullException.ThrowIfNull(book, nameof(book));
        var newBook = new Book
        {
            Id = Guid.NewGuid(),
            Title = book.Title,
            ISBN = book.ISBN,
            Description = book.Description,
            Genre = book.Genre,
            PublishedDate = book.PublishedDate,
        };
        _books.Add(newBook);

        var newAuthor = new Author
        {
            Id = Guid.NewGuid(),
            Name = book.Author,
            ProfileImageUrl = book.AuthorProfileImageUrl,
            Books = new List<Book> { newBook }
        };
        _authors.Add(newAuthor);

        var newBookItem = new BookCopy
        {
            Id = Guid.NewGuid(),
            CoverImageUrl = book.CoverImageUrl,
            Condition = book.Condition,
            Source = book.Source,
            AddedDate = DateTime.Now,
            Book = newBook
        };
        _bookCopies.Add(newBookItem);
    }

    public IEnumerable<BookListViewModel> GetBooks()
    {
        return _books.Where(b => !b.IsArchived).Select(b => new BookListViewModel
        {
            BookId = b.Id,
            Title = b.Title,
            ISBN = b.ISBN,
            Description = b.Description,
            Genre = b.Genre,
            
            PublishedDate = b.PublishedDate,
            CoverImageUrl = _bookCopies.FirstOrDefault(bi => bi.Book.Id == b.Id)?.CoverImageUrl,
            AuthorId = _authors.FirstOrDefault(a => a.Books.Any(bk => bk.Id == b.Id))?.Id,
            AuthorName = _authors.FirstOrDefault(a => a.Books.Any(bk => bk.Id == b.Id))?.Name,
            AuthorProfileImageUrl = _authors.FirstOrDefault(a => a.Books.Any(bk => bk.Id == b.Id))?.ProfileImageUrl,
            TotalCopies = _bookCopies.Count(bi => bi.Book.Id == b.Id),
            AvailableCopies = _bookCopies.Count(bi => bi.Book.Id == b.Id && bi.PulloutDate == null && bi.IsAvailable),
            PulledOutCopies = _bookCopies.Count(bi => bi.Book.Id == b.Id && bi.PulloutDate != null),
            IsArchived = b.IsArchived,
            ArchivedDate = b.ArchivedDate
        });
    }

    public EditBookViewModel GetBookById(Guid id)
    {
        var bookViewModel = GetBooks().FirstOrDefault(b => b.BookId == id) ?? throw new KeyNotFoundException("Book not found");
        var editBookViewModel = new EditBookViewModel
        {
            BookId = bookViewModel.BookId,
            Title = bookViewModel.Title,
            ISBN = bookViewModel.ISBN,
            Description = bookViewModel.Description,
            Genre = bookViewModel.Genre,
            PublishedDate = bookViewModel.PublishedDate,
            AuthorId = _authors.FirstOrDefault(a => a.Name == bookViewModel.AuthorName)?.Id,
            Author = bookViewModel.AuthorName,
            AuthorProfileImageUrl = bookViewModel.AuthorProfileImageUrl,
            CoverImageUrl = bookViewModel.CoverImageUrl,
        };

        return editBookViewModel ?? throw new KeyNotFoundException("Book not found");
    }

    internal void UpdateBook(EditBookViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm, nameof(vm));

        var book = _books.FirstOrDefault(b => b.Id == vm.BookId) ?? throw new KeyNotFoundException("Book not found");
        book.Title = vm.Title;
        book.ISBN = vm.ISBN;
        book.Description = vm.Description;
        book.Genre = vm.Genre;
        book.PublishedDate = vm.PublishedDate;
        

        var author = _authors.FirstOrDefault(a => a.Id == vm.AuthorId);
        if (author == null)
        {
            author = new Author
            {
                Id = Guid.NewGuid(),
                Name = vm.Author,
                ProfileImageUrl = vm.AuthorProfileImageUrl,
                Books = new List<Book> { book }
            };
            _authors.Add(author);
        }
        else
        {
            author.Name = vm.Author;
            author.ProfileImageUrl = vm.AuthorProfileImageUrl;
        }

        var bookCopy = _bookCopies.FirstOrDefault(bi => bi.Book.Id == vm.BookId);
        if (bookCopy != null)
        {
            bookCopy.CoverImageUrl = vm.CoverImageUrl;
        }
        else
        {
            bookCopy = new BookCopy
            {
                Id = Guid.NewGuid(),
                CoverImageUrl = vm.CoverImageUrl,
                AddedDate = DateTime.Now,
                Book = book
            };
            _bookCopies.Add(bookCopy);
        }
    }

    public void DeleteBook(Guid id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id) ?? throw new KeyNotFoundException("Book not found");
        _books.Remove(book);
        var author = _authors.FirstOrDefault(a => a.Books.Any(bk => bk.Id == id));
        if (author != null)
        {
            author.Books.Remove(book);
            if (!author.Books.Any())
            {
                _authors.Remove(author);
            }
        }
        var bookCopies = _bookCopies.Where(bi => bi.Book.Id == id).ToList();
        foreach (var bookCopy in bookCopies)
        {
            _bookCopies.Remove(bookCopy);
        }
    }

    private static readonly Lazy<BookService> _instance = new(() => new BookService());
    public static BookService Instance => _instance.Value;

    public void AddCopies(Guid bookId, int numberOfCopies)
    {
        var book = _books.FirstOrDefault(b => b.Id == bookId);
        if (book == null)
        {
            throw new KeyNotFoundException("Book not found");
        }

        for (int i = 0; i < numberOfCopies; i++)
        {
            var newCopy = new BookCopy
            {
                Id = Guid.NewGuid(),
                Condition = "New",
                Source = "Purchase",
                AddedDate = DateTime.Now,
                Book = book
            };
            _bookCopies.Add(newCopy);
        }
    }

    public IEnumerable<Author> GetAllAuthors()
    {
        return _authors;
    }

    public void AddAuthor(Author author)
    {
        ArgumentNullException.ThrowIfNull(author, nameof(author));
        _authors.Add(author);
    }

    public void UpdateAuthor(Library_Management.Models.EditAuthorViewModel viewModel)
    {
        ArgumentNullException.ThrowIfNull(viewModel, nameof(viewModel));
        
        var author = _authors.FirstOrDefault(a => a.Id == viewModel.AuthorId);
        if (author == null) throw new KeyNotFoundException("Author not found");
        
        author.Name = viewModel.Name;
        author.Biography = viewModel.Biography;
        author.BirthDate = viewModel.BirthDate;
        author.ProfileImageUrl = viewModel.ProfileImageUrl;
        author.IsArchived = viewModel.IsArchived;
    }

    public void ArchiveAuthor(Guid id)
    {
        var author = _authors.FirstOrDefault(a => a.Id == id);
        if (author == null) throw new KeyNotFoundException("Author not found");
        
        author.IsArchived = true;
        author.ArchivedDate = DateTime.Now;
   
        foreach (var book in author.Books)
        {
            book.IsArchived = true;
            book.ArchivedDate = DateTime.Now;
        }
    }

    public void RestoreAuthor(Guid id)
    {
        var author = _authors.FirstOrDefault(a => a.Id == id);
        if (author == null) throw new KeyNotFoundException("Author not found");
        
        author.IsArchived = false;
        author.ArchivedDate = null;
      
    }

    public void ArchiveBook(Guid id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book == null) throw new KeyNotFoundException("Book not found");
        
        book.IsArchived = true;
        book.ArchivedDate = DateTime.Now;
    }

    public void RestoreBook(Guid id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book == null) throw new KeyNotFoundException("Book not found");
        
        book.IsArchived = false;
        book.ArchivedDate = null;
    }

    public IEnumerable<BookListViewModel> GetArchivedBooks()
    {
        return _books.Where(b => b.IsArchived).Select(b => new BookListViewModel
        {
            BookId = b.Id,
            Title = b.Title,
            ISBN = b.ISBN,
            Description = b.Description,
            Genre = b.Genre,
            PublishedDate = b.PublishedDate,
            CoverImageUrl = _bookCopies.FirstOrDefault(bi => bi.Book.Id == b.Id)?.CoverImageUrl,
            AuthorId = _authors.FirstOrDefault(a => a.Books.Any(bk => bk.Id == b.Id))?.Id,
            AuthorName = _authors.FirstOrDefault(a => a.Books.Any(bk => bk.Id == b.Id))?.Name,
            AuthorProfileImageUrl = _authors.FirstOrDefault(a => a.Books.Any(bk => bk.Id == b.Id))?.ProfileImageUrl,
            TotalCopies = _bookCopies.Count(bi => bi.Book.Id == b.Id),
            AvailableCopies = _bookCopies.Count(bi => bi.Book.Id == b.Id && bi.PulloutDate == null && bi.IsAvailable),
            PulledOutCopies = _bookCopies.Count(bi => bi.Book.Id == b.Id && bi.PulloutDate != null),
            IsArchived = b.IsArchived,
            ArchivedDate = b.ArchivedDate
        });
    }

    public IEnumerable<BookCopy> GetBookCopies(Guid bookId)
    {
        return _bookCopies.Where(bc => bc.Book.Id == bookId);
    }

    public void PulloutBookCopy(Guid bookCopyId, string reason)
    {
        ArgumentException.ThrowIfNullOrEmpty(reason, nameof(reason));
        
        var bookCopy = _bookCopies.FirstOrDefault(bc => bc.Id == bookCopyId);
        if (bookCopy == null) throw new KeyNotFoundException("Book copy not found");
        
        bookCopy.PulloutDate = DateTime.Now;
        bookCopy.PulloutReason = reason;
        bookCopy.IsAvailable = false;
    }

    public BookCopy? GetBookCopyById(Guid bookCopyId)
    {
        return _bookCopies.FirstOrDefault(bc => bc.Id == bookCopyId);
    }
}
