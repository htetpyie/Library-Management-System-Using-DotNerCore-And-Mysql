using LMS.Data.Context;
using LMS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service.Repository
{
    public class BookRepository
    {
        private readonly DbContextLMS _context;
        public BookRepository(DbContextLMS context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _context.Book.Where(b => b.IsDelete == false).ToListAsync();
        }

        public int SaveBook(Book bookData, int loginUserId)
        {
            Book bookModel = new Book();

            bookModel.CreatedBy = loginUserId;
            bookModel.CreatedDate = DateTime.Now;
            bookModel.Title = bookData.Title;
            bookModel.Author = bookData.Author;
            bookModel.Publisher = bookData.Publisher;
            bookModel.PublishedDate = bookData.PublishedDate;
            bookModel.ISBN = bookData.ISBN;

            _context.Add(bookModel);
            return _context.SaveChanges();
        }

        public Book FindBookById(int bookId)
        {
            return _context.Book.Where(b => b.IsDelete == false && b.Id = bookId).FirstOrDefault();
        }

        public int UpdateBook(Book bookData, int loginUserId)
        {
            Book bookModel = _context.Book.Where(b => b.IsDelete == false && b.Id == bookData.Id).FirstOrDefault();
            if (bookModel == null) return -1;

            bookModel.UpdatedBy = loginUserId;
            bookModel.UpdatedDate = DateTime.Now;
            bookModel.Title = bookData.Title;
            bookModel.Author = bookData.Author;
            bookModel.Publisher = bookData.Publisher;
            bookModel.PublishedDate = bookData.PublishedDate;
            bookModel.ISBN = bookData.ISBN;

            _context.Update(bookModel);
            return _context.SaveChanges();
        }

        public int DeleteBook(int bookId, int loginUserId)
        {
            Book bookModel = _context.Book.Where(b => b.IsDelete == false && b.Id == bookId).FirstOrDefault();
            if (bookModel == null) return -1;

            bookModel.UpdatedBy = loginUserId;
            bookModel.UpdatedDate = DateTime.Now;
            bookModel.IsDelete = true;

            _context.Update(bookModel);
            return _context.SaveChanges();
        }
    }
}
