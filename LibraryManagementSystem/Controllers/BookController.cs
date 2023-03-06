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

        // Book Data Table
        [HttpPost]
        public async Task<IActionResult> BookDataTable()
        {
            try
            {

                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();

                // Skiping number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();

                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                // Sort Column Name  
                //var sortColumn = Request.Form["order[0][column]"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

                // Sort Column Direction ( asc ,desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

                //Paging Size (10,20,50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                // Getting all User data  
                var roleList = await _iBookService.GetAllBook(sortColumn, sortColumnDirection, searchValue, skip, pageSize);

                //total number of rows count   
                recordsTotal = roleList.Count();
                //Paging   
                var data = roleList.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data });
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Create Book
        public IActionResult CreateBook()
        {
            return View();
        }

        // Save Book
        [HttpPost]
        public async Task<IActionResult> SaveBook(BookVM bookVM)
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
        public async Task<IActionResult> ViewBook(int id)
        {
            BookVM bookVm = await _iBookService.GetBookById(id);
            if (bookVm == null)
            {
                TempData[Message] = _message.BookNotFound;
                return NotFound();
            }
            return View(bookVm);
        }

        // Edit Book
        public async Task<IActionResult> EditBook(int Id)
        {

            BookVM bookVm = await _iBookService.GetBookById(Id);
            if (bookVm == null)
            {
                TempData[Message] = _message.BookNotFound;
                return RedirectToAction(nameof(Index));
            }
            return View(bookVm);
        }

        // Update Book
        [HttpPost]
        public async Task<IActionResult> UpdateBook(BookVM bookVm)
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
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteBook(int Id)
        {
            int loginUserId = 1;
            bool isDeleted = await _iBookService.DeleteBook(Id, loginUserId);
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
    
        [HttpPost]
        [ActionName("Search")]
        public async Task<IActionResult> SearchBook(FilterModel reqModel)
        {
            var list = await _iBookService.GetBookByFilter(reqModel.Filter);
            return Json(new { result = list });
        }
    }

    public class FilterModel
    {
        public string Filter { get; set; }
    }
}
