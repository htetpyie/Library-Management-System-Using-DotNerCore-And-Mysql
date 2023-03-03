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

        // Retrieve All
        public async Task<List<BookDM>> GetAllBooks(int pageNo, int rowCount)
        {
            int skip = (pageNo - 1) * rowCount;
            var list = await _context.Book.AsNoTracking()
                                        .Where(b => b.IsDelete == false)
                                        .Skip(skip)
                                        .Take(rowCount)
                                        .ToListAsync();
            return list;
        }

        // Duplicate Method
        public async Task<bool> IsDuplicate(BookDM book)
        {
            bool isDuplicate;
            if (book.Id > 0)
            {
                isDuplicate = await _context.Book.AnyAsync(b => b.IsDelete == false && b.Id != book.Id
                                   && b.Title.ToLower().Trim() == book.Title.ToLower().Trim()
                                   && b.Author.ToLower().Trim() == book.Author.ToLower().Trim());
            }
            else
            {
                isDuplicate = await _context.Book.AnyAsync(b => b.IsDelete == false
                                    && b.Title.ToLower().Trim() == book.Title.ToLower().Trim()
                                    && b.Author.ToLower().Trim() == book.Author.ToLower().Trim());
            }

            return isDuplicate;

        }

        // Create
        public async Task<bool> SaveBook(BookDM bookData, int loginUserId)
        {
            BookDM bookModel = new BookDM();

            bookModel.CreatedBy = loginUserId;
            bookModel.CreatedDate = DateTime.Now;
            bookModel.Title = bookData.Title;
            bookModel.Author = bookData.Author;
            bookModel.Publisher = bookData.Publisher;
            bookModel.PublishedDate = bookData.PublishedDate;
            bookModel.ISBN = bookData.ISBN;
            bookModel.Description = bookData.Description;

            await _context.AddAsync(bookModel);

            int result = _context.SaveChanges();
            return result > 0;
        }

        // Retrieve By Id
        public async Task<BookDM> GetBookById(int bookId)
        {
            BookDM book = await _context.Book.FirstOrDefaultAsync(b => b.IsDelete == false && b.Id == bookId);
            return book;
        }

        // Update
        public async Task<bool> UpdateBook(BookDM bookData, int loginUserId)
        {
            BookDM bookModel = await _context.Book.FirstOrDefaultAsync(b => b.IsDelete == false && b.Id == bookData.Id);
            if (bookModel == null) return false;

            bookModel.UpdatedBy = loginUserId;
            bookModel.UpdatedDate = DateTime.Now;
            bookModel.Title = bookData.Title;
            bookModel.Author = bookData.Author;
            bookModel.Publisher = bookData.Publisher;
            bookModel.PublishedDate = bookData.PublishedDate;
            bookModel.ISBN = bookData.ISBN;
            bookModel.Description = bookData.Description;

            _context.Entry(bookModel).State = EntityState.Modified;
            _context.Update(bookModel);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        // Delete
        public async Task<bool> DeleteBook(int bookId, int loginUserId)
        {
            BookDM bookModel = await _context.Book.FirstOrDefaultAsync(b => b.IsDelete == false && b.Id == bookId);
            if (bookModel == null) return false;

            bookModel.UpdatedBy = loginUserId;
            bookModel.UpdatedDate = DateTime.Now;
            bookModel.IsDelete = true;

            _context.Entry(bookModel).State = EntityState.Deleted;
            _context.Update(bookModel);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
