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

namespace LMS.Service.Implementations {
    public class BookService : IBookService {
        #region Fields
        private readonly BookRepository _bookRepo;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public BookService(BookRepository bookRepo, IMapper mapper) {
            _bookRepo = bookRepo;
            _mapper = mapper;
        }
        #endregion

        #region Bussiness Logic Layer
        // Read , Retrieve All
        public async Task<List<BookVM>> GetAllBook(int pageNo, int rowCount) {
            List<BookDM> bookList = await _bookRepo.GetAllBooks(pageNo, rowCount);

            //List<BookVM> resultBookList = bookList.Select(item => _mapper.Map<BookVM>(item)).ToList();
            //List<BookVM> resultBookList = bookList.Select(item => item.Change()).ToList();
            //List<BookVM> resultBookList = bookList.Select(item => new BookVM {
            //    Id = item.Id,
            //    Author = item.Author,
            //    Description = item.Description,
            //    ISBN = item.ISBN,
            //    PublishedDate = item.PublishedDate,
            //    Publisher = item.Publisher,
            //    Title = item.Title,
            //}).ToList();
            List<BookVM> resultBookList = new List<BookVM>();
            foreach (var item in bookList) {
                BookVM bookVM = new BookVM {
                    Id = item.Id,
                    Author = item.Author,
                    Description = item.Description,
                    ISBN = item.ISBN,
                    PublishedDate = item.PublishedDate,
                    Publisher = item.Publisher,
                    Title = item.Title,
                };
                resultBookList.Add(bookVM);
            }
            return resultBookList;
        }

        // Check Duplicate
        public async Task<bool> IsDuplicate(BookVM bookVM) {
            if (bookVM == null) return false;
            bool isDuplicate = await _bookRepo.IsDuplicate(_mapper.Map<BookDM>(bookVM));
            return isDuplicate;
        }

        // Create
        public async Task<bool> SaveBook(BookVM bookVM, int loginUserId) {
            BookDM book = _mapper.Map<BookDM>(bookVM);
            bool isSaved = await _bookRepo.SaveBook(book, loginUserId);
            return isSaved;
        }

        // Retrieve By Id
        public async Task<BookVM> GetBookById(int bookId) {
            BookDM book = await _bookRepo.GetBookById(bookId);
            BookVM bookVM = _mapper.Map<BookVM>(book);
            return bookVM;
        }

        // Update Book
        public async Task<bool> UpdateBook(BookVM bookVm, int loginUserId) {
            BookDM book = _mapper.Map<BookDM>(bookVm);
            bool isUpdated = await _bookRepo.UpdateBook(book, loginUserId);
            return isUpdated;
        }

        //Delete Book
        public async Task<bool> DeleteBook(int bookId, int loginUserId) {
            bool isDeleted = await _bookRepo.DeleteBook(bookId, loginUserId);
            return isDeleted;
        }
        #endregion
    }
}
