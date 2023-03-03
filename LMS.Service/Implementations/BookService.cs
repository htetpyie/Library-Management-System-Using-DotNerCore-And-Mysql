using AutoMapper;
using LMS.Data.Models;
using LMS.Data.ViewModels;
using LMS.Service.Interfaces;
using LMS.Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service.Implementations
{
    public class BookService : IBookService
    {
        #region Fields
        private readonly BookRepository _bookRepo;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public BookService(BookRepository bookRepo, IMapper mapper)
        {
            _bookRepo = bookRepo;
            _mapper = mapper;
        }
        #endregion

        #region Bussiness Logic Layer
        // Read , Retrieve All
        public async Task<List<ViewBookVM>> GetAllBook(int pageNo, int rowCount)
        { 
            List<Book> bookList = await _bookRepo.GetAllBooks(pageNo, rowCount);
            //List<ViewBookVM> resultBookList = _mapper.Map<List<ViewBookVM>>(bookList);
            List<ViewBookVM> resultBookList = bookList.Select(item => _mapper.Map<ViewBookVM>(item)).ToList();
            return resultBookList;
        }
        
        // Check Duplicate
        public async Task<bool> IsDuplicate(ViewBookVM bookVM)
        {
            if (bookVM == null) return false;
            bool isDuplicate =  await _bookRepo.IsDuplicate( _mapper.Map<Book>(bookVM) );
            return isDuplicate;
        }

        // Create
        public async Task<bool> SaveBook(ViewBookVM bookVM, int loginUserId)
        {
            Book book = _mapper.Map<Book>(bookVM);
            bool isSaved = await _bookRepo.SaveBook(book, loginUserId);
            return isSaved;
        }

        // Retrieve By Id
        public async Task<ViewBookVM> GetBookById(int bookId)
        {
            Book book = await _bookRepo.GetBookById(bookId);
            ViewBookVM bookVM = _mapper.Map<ViewBookVM>(book);
            return bookVM;
        }
        
        // Update Book
        public async Task<bool> UpdateBook(ViewBookVM bookVm, int loginUserId)
        {
            Book book = _mapper.Map<Book>(bookVm);
            bool isUpdated = await _bookRepo.UpdateBook(book, loginUserId);
            return isUpdated;
        }

        //Delete Book
        public async Task<bool> DeleteBook(int bookId, int loginUserId)
        {
            bool isDeleted = await _bookRepo.DeleteBook(bookId, loginUserId);
            return isDeleted;
        }
        #endregion
    }
}
