using Library_Management.Models;
using Library_Management.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AuthorService _authorService = new AuthorService();
        public IActionResult Index()
        {
            var authors = _authorService.GetAuthors().ToList();
            return View(authors);
        }

        public IActionResult Details(Guid id)
        {
            var author = _authorService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddAuthorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _authorService.AddAuthor(viewModel);
                    TempData["SuccessMessage"] = $"Author '{viewModel.Name}' has been successfully added!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"An error occurred while adding the author: {ex.Message}");
                }
            }
            return View(viewModel);
        }

        public IActionResult Edit(Guid id)
        {
            var author = _authorService.GetAuthorForEdit(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, EditAuthorViewModel viewModel)
        {
            if (id != viewModel.AuthorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _authorService.UpdateAuthor(viewModel);
                    TempData["SuccessMessage"] = $"Author '{viewModel.Name}' has been successfully updated!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"An error occurred while updating the author: {ex.Message}");
                }
            }
            return View(viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            var author = _authorService.GetAuthorForDelete(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                var author = _authorService.GetAuthorForDelete(id);
                if (author == null)
                {
                    return NotFound();
                }

                _authorService.DeleteAuthor(id);
                TempData["SuccessMessage"] = $"Author '{author.Name}' and their books have been archived successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred while archiving the author: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Archive()
        {
            var archivedAuthors = _authorService.GetArchivedAuthors().ToList();
            return View(archivedAuthors);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Restore(Guid id)
        {
            try
            {
                _authorService.RestoreAuthor(id);
                TempData["SuccessMessage"] = "Author has been restored successfully!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred while restoring the author: {ex.Message}";
            }
            return RedirectToAction(nameof(Archive));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ArchiveAuthor(Guid id)
        {
            try
            {
                var author = _authorService.GetAuthorForDelete(id);
                if (author == null)
                {
                    return NotFound();
                }

                _authorService.ArchiveAuthor(id);
                TempData["SuccessMessage"] = $"Author '{author.Name}' has been archived successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred while archiving the author: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
