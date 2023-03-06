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
        private readonly LMSDbContext _context;
        public BookRepository(LMSDbContext context)
        {
            _context = context;
        }

        // Retrieve All
        public async Task<List<BookDM>> GetAllBooks(int pageNo, int rowCount)
        {
            //int skip = (pageNo - 1) * rowCount;
            int skip = pageNo; // as pageNo = dataTableModel.Skip in service
            var list = await _context.Book.AsNoTracking()                                       
                                        .Skip(skip)
                                        .Take(rowCount)
                                        .ToListAsync();
            return list;
        }

        // Duplicate Method
        public async Task<bool> IsDuplicate(BookDM book)
        {
            bool isDuplicate;
            if (book.BookId > 0)
            {
                isDuplicate = await _context.Book.AnyAsync(b => b.BookId != book.BookId
                                   && b.Title.ToLower().Trim() == book.Title.ToLower().Trim()
                                   && b.Author.ToLower().Trim() == book.Author.ToLower().Trim());
            }
            else
            {
                isDuplicate = await _context.Book.AnyAsync(b => 
                                    b.Title.ToLower().Trim() == book.Title.ToLower().Trim()
                                    && b.Author.ToLower().Trim() == book.Author.ToLower().Trim());
            }

            return isDuplicate;

        }

        // Create
        public async Task<bool> SaveBook(BookDM bookData, int loginUserId)
        {
            BookDM bookModel = new BookDM();
                        
            bookModel.Title = bookData.Title;
            bookModel.Author = bookData.Author;
            bookModel.Publisher = bookData.Publisher;
            bookModel.PublishDate = bookData.PublishDate;
            bookModel.ISBN = bookData.ISBN;

            await _context.AddAsync(bookModel);

            int result = _context.SaveChanges();
            return result > 0;
        }

        // Retrieve By Id
        public async Task<BookDM> GetBookById(int bookId)
        {
            BookDM book = await _context.Book.FirstOrDefaultAsync(b => b.BookId == bookId);
            return book;
        }

        // Update
        public async Task<bool> UpdateBook(BookDM bookData, int loginUserId)
        {
            BookDM bookModel = await _context.Book.FirstOrDefaultAsync(b => b.BookId == bookData.BookId);
            if (bookModel == null) return false;
                        
            bookModel.Title = bookData.Title;
            bookModel.Author = bookData.Author;
            bookModel.Publisher = bookData.Publisher;
            bookModel.PublishDate = bookData.PublishDate;
            bookModel.ISBN = bookData.ISBN;

            _context.Entry(bookModel).State = EntityState.Modified;
            _context.Update(bookModel);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        // Delete
        public async Task<bool> DeleteBook(int bookId, int loginUserId)
        {
            BookDM bookModel = await _context.Book.FirstOrDefaultAsync(b => b.BookId == bookId);
            if (bookModel == null) return false;
           

            _context.Entry(bookModel).State = EntityState.Deleted;
            _context.Remove(bookModel);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        // Get Book by Filter
        public async Task<List<BookDM>> GetBookByFilter(string filter)
        {
            string filterData = filter?.ToLower();
            IQueryable<BookDM> query = _context.Book.AsNoTracking();

            List<BookDM> bookList = new List<BookDM>();
            if(filterData != null && !string.IsNullOrEmpty(filterData))
            {
                query = query.Where(
                            q =>
                            q.BookId.ToString().Contains(filterData) ||
                            q.Title.ToLower().Contains(filterData) ||
                            q.ISBN.ToLower().Contains(filterData)
                        );
            }
            bookList = await query.ToListAsync();
            return bookList;

        }
    }
}
