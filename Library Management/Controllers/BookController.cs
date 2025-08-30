using Library_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controllers
{
    public class BookController : Controller //var bookController = new BookController(new BookService());
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var books =_bookService.GetBooks();
            return View(books);
        }

        public IActionResult Add()
        {
            return View();
        }

     
        public IActionResult EditModal(Guid id)
        {
            var editBookViewModel =_bookService.GetBookById(id);
            if (editBookViewModel == null) return NotFound();

          
            return PartialView("_EditBookPartial", editBookViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditBookViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                // If model state is not valid, you can return a view with validation errors
                return BadRequest(ModelState);
            }

            // Assuming BookService has a method to update the book
           _bookService.UpdateBook(vm);

            return Ok();
        }

        public IActionResult DeleteModal(Guid id)
        {
            
            return PartialView("_DeletePartial");
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            // Assuming BookService has a method to delete the book
           _bookService.DeleteBook(id);
            return Ok();
        }

        public IActionResult Details(Guid id)
        {
            var book =_bookService.GetBooks().First(b => b.BookId == id);
            return View(book);
        }


    }
}
