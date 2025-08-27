using Library_Management.Models;
using Library_Management_Domain.Entities;

namespace Library_Management.Services
{
    public class AuthorService
    {
        private readonly BookService _bookService = BookService.Instance;

        public IEnumerable<AuthorListViewModel> GetAuthors(bool includeArchived = false)
        {
            var authors = _bookService.GetAllAuthors();
            if (!includeArchived)
            {
                authors = authors.Where(a => !a.IsArchived);
            }

            return authors.Select(a => new AuthorListViewModel
            {
                AuthorId = a.Id,
                Name = a.Name,
                Biography = a.Biography,
                BirthDate = a.BirthDate,
                ProfileImageUrl = a.ProfileImageUrl,
                ActiveBooksCount = a.ActiveBooksCount,
                TotalBooksCount = a.TotalBooksCount,
                IsArchived = a.IsArchived,
                ArchivedDate = a.ArchivedDate
            });
        }

        public AuthorDetailsViewModel? GetAuthorById(Guid id)
        {
            var author = _bookService.GetAllAuthors().FirstOrDefault(a => a.Id == id);
            if (author == null) return null;

            var books = _bookService.GetBooks().Where(b => b.AuthorId == id).ToList();

            return new AuthorDetailsViewModel
            {
                AuthorId = author.Id,
                Name = author.Name,
                Biography = author.Biography,
                BirthDate = author.BirthDate,
                ProfileImageUrl = author.ProfileImageUrl,
                IsArchived = author.IsArchived,
                ArchivedDate = author.ArchivedDate,
                Books = books
            };
        }

        public EditAuthorViewModel? GetAuthorForEdit(Guid id)
        {
            var author = _bookService.GetAllAuthors().FirstOrDefault(a => a.Id == id);
            if (author == null) return null;

            return new EditAuthorViewModel
            {
                AuthorId = author.Id,
                Name = author.Name ?? string.Empty,
                Biography = author.Biography,
                BirthDate = author.BirthDate,
                ProfileImageUrl = author.ProfileImageUrl,
                IsArchived = author.IsArchived
            };
        }

        public DeleteAuthorViewModel? GetAuthorForDelete(Guid id)
        {
            var author = _bookService.GetAllAuthors().FirstOrDefault(a => a.Id == id);
            if (author == null) return null;

            return new DeleteAuthorViewModel
            {
                AuthorId = author.Id,
                Name = author.Name,
                Biography = author.Biography,
                BirthDate = author.BirthDate,
                ProfileImageUrl = author.ProfileImageUrl,
                ActiveBooksCount = author.ActiveBooksCount,
                TotalBooksCount = author.TotalBooksCount
            };
        }

        public void AddAuthor(AddAuthorViewModel viewModel)
        {
            ArgumentNullException.ThrowIfNull(viewModel, nameof(viewModel));

            var author = new Author
            {
                Id = Guid.NewGuid(),
                Name = viewModel.Name,
                Biography = viewModel.Biography,
                BirthDate = viewModel.BirthDate,
                ProfileImageUrl = viewModel.ProfileImageUrl,
                IsArchived = false,
                Books = new List<Book>()
            };

            _bookService.AddAuthor(author);
        }

        public void UpdateAuthor(EditAuthorViewModel viewModel)
        {
            ArgumentNullException.ThrowIfNull(viewModel, nameof(viewModel));
            _bookService.UpdateAuthor(viewModel);
        }

        public void DeleteAuthor(Guid id)
        {
            _bookService.ArchiveAuthor(id);
        }

        public void ArchiveAuthor(Guid id)
        {
            _bookService.ArchiveAuthor(id);
        }

        public void RestoreAuthor(Guid id)
        {
            _bookService.RestoreAuthor(id);
        }

        public IEnumerable<AuthorListViewModel> GetArchivedAuthors()
        {
            return GetAuthors(includeArchived: true).Where(a => a.IsArchived);
        }
    }
}
