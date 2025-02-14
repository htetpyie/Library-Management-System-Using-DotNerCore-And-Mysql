﻿using LMS.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service.Interfaces
{
    public interface IBookService
    {
        //Task<List<BookVM>> GetAllBook(string sortColumn, string sortColumnDirection,string searchValue);
        Task<List<BookVM>> GetAllBook(string sortColumn, string sortColumnDirection,string searchValue, int skip, int count);
        Task<bool> IsDuplicate(BookVM bookVM);
        Task<bool> SaveBook(BookVM bookVM, int loginUserId);
        Task<BookVM> GetBookById(int bookId);
        Task<bool> UpdateBook(BookVM bookVm, int loginUserId);
        Task<bool> DeleteBook(int bookId, int loginUserId);
        Task<List<BookVM>> GetBookByFilter(string filter);
    }
}
