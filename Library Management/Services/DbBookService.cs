using Library_Management.Data;
using Library_Management.Models;

public class DbBookService : IBookService
{
    private readonly BookDbContext _bookdBContext;

    public DbBookService(BookDbContext context)
    {
        _bookdBContext = context;
    }

    public void AddBook(AddBookViewModel book)
    {
        throw new NotImplementedException();
    }

    public void DeleteBook(Guid id)
    {
        throw new NotImplementedException();
    }

    public EditBookViewModel GetBookById(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<BookListViewModel> GetBooks()
    {
        return _bookdBContext.Books.Select(b => new BookListViewModel
        {
            BookId = b.Id,
            Title = b.Title,
            Genre = b.Genre,
            PublishedDate = b.PublishedDate,
           
        }).ToList();
    }

    public void UpdateBook(EditBookViewModel vm)
    {
        throw new NotImplementedException();
    }
}
