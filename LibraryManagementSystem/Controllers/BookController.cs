using LMS.Data.ViewModels;
using LMS.Service.Interfaces;
using LMS.Web.Constants;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _iBookService;
        private readonly Message _message = new Message();
        private const string Message = "Message";
        private const string MessageTitle = "MessageTitle";

        public BookController(IBookService bookService)
        {
            _iBookService = bookService;
        }

        // Index
        public IActionResult Index()
        {
            return View();
        }

        // Create Book
        public IActionResult CreateBook()
        {
            return View();
        }

        // Save Book
        [HttpPost]
        public async Task<IActionResult> SaveBook(ViewBookVM bookVM)
        {
            int loginUserId = 1;

            if (!ModelState.IsValid) return RedirectToAction(nameof(CreateBook));

            bool isSaved = await _iBookService.SaveBook(bookVM, loginUserId);
            if (isSaved)
            {
                TempData[Message] = _message.BookSaveSuccess;
                TempData[MessageTitle] = _message.BookMessageTitle;
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData[Message] = _message.BookSaveError;
                TempData[MessageTitle] = _message.BookMessageTitle;
                return RedirectToAction(nameof(CreateBook));
            }
        }
        
        // View Book
        public async Task<IActionResult> ViewBook(int bookId)
        {
            ViewBookVM bookVm = await _iBookService.GetBookById(bookId);
            if (bookVm == null)
            {
                TempData[Message] = _message.BookNotFound;
                return NotFound();
            }
            return View(bookVm);
        }

        // Edit Book
        public async Task<IActionResult> EditBook(int bookId)
        {

            ViewBookVM bookVm = await _iBookService.GetBookById(bookId);
            if (bookVm == null)
            {
                TempData[Message] = _message.BookNotFound;
                return NotFound();
            }
            return View(bookVm);
        }

        // Update Book
        [HttpPost]
        public async Task<IActionResult> UpdateBook(ViewBookVM bookVm)
        {
            int loginUserId = 1;
            if (bookVm == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();

            bool isUpdated = await _iBookService.UpdateBook(bookVm, loginUserId);
            if (isUpdated)
            {
                TempData[Message] = _message.BookUpdateSuccess;
                TempData[MessageTitle] = _message.BookMessageTitle;
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData[Message] = _message.BookUpdateError;
                TempData[MessageTitle] = _message.BookMessageTitle;
                return RedirectToAction(nameof(EditBook));
            }
        }
    
        // Delete Book
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            int loginUserId = 1;
            bool isDeleted = await _iBookService.DeleteBook(bookId, loginUserId);
            if (isDeleted)
            {
                TempData[Message] = _message.BookDeleteSuccess;                
            }
            else
            {
                TempData[Message] = _message.BookDeleteError;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
