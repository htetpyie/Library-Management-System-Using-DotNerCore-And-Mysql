using LMS.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service.Interfaces
{
    public interface IBookService
    {
        Task<List<ViewBookVM>> GetAllBook(int pageNo, int rowCount);
        Task<bool> IsDuplicate(ViewBookVM bookVM);
        Task<bool> SaveBook(ViewBookVM bookVM, int loginUserId);
        Task<ViewBookVM> GetBookById(int bookId);
        Task<bool> UpdateBook(ViewBookVM bookVm, int loginUserId);
        Task<bool> DeleteBook(int bookId, int loginUserId);
    }
}
